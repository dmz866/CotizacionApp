using CotizacionApp.Core.Entities;
using CotizacionApp.Core.Interfaces;
using CotizacionApp.Core.Utils;
using CotizacionApp.Infrastructure.Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace CotizacionApp.Infrastructure.Services
{
    public class CotizacionService : ICotizacionService
    {
        private readonly CotizacionAppContext _context;
        private readonly IUtilsService _utilsService;
        private HttpClient _client;
        public CotizacionService(CotizacionAppContext context, IUtilsService utilsService)
        {
            _context = context;
            _utilsService = utilsService;
            _client = new HttpClient();
        }
        public async Task<Response<Cotizacion>> GetCotizacion(string moneda)
        {
            try
            {
                var monedasAceptadasList = await _utilsService.GetMonedasAceptadas();
                if (string.IsNullOrEmpty(moneda) || !monedasAceptadasList.Any(m => m.Value.Equals(moneda.ToLower())))
                {
                    throw new Exception(Constants.MONEDA_NO_ACEPTADA);
                }

                var response = await _client.GetAsync(Constants.BANCO_PROVINCIA_END_POINT_URL);
                var content = response.Content.ReadAsStringAsync().Result;
                string[] result = content.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Split(',');
                Cotizacion cotizacion = new Cotizacion();
                cotizacion.Compra = Convert.ToDouble(result[0]);
                cotizacion.Venta = Convert.ToDouble(result[1]);
                cotizacion.Mensaje = result[2];

                if(moneda.Equals(Constants.MONEDA_REAL))
                {
                    cotizacion.Compra = cotizacion.Compra * Constants.COTIZACION_REAL_DOLAR;
                    cotizacion.Venta = cotizacion.Venta * Constants.COTIZACION_REAL_DOLAR;
                }

                return new Response<Cotizacion>()
                {
                    Success = true,
                    Data = cotizacion
                };
            }
            catch(Exception ex)
            {
                return new Response<Cotizacion>()
                {
                    Success = false,
                    Message = ex.Message
                };
            }            
        }
        public async Task<Response<Transaccion>> ComprarMoneda(Transaccion transaccion)
        {
            try
            {
                var monedasAceptadasList = await _utilsService.GetMonedasAceptadas();
                if (string.IsNullOrEmpty(transaccion.Moneda) || !monedasAceptadasList.Any(m => m.Value.Equals(transaccion.Moneda.ToLower())))
                {
                    throw new Exception(Constants.MONEDA_NO_ACEPTADA);
                }

                var montoActual = _context.Transaccion
                                        .Where(t => t.UsuarioId.Equals(transaccion.UsuarioId) && 
                                        t.CreatedOn.Month.Equals(DateTime.Now.Month) &&
                                        t.Moneda.Equals(transaccion.Moneda))
                                        .Sum(t => t.Monto);
                montoActual += transaccion.Monto;

                if (transaccion.Moneda.Equals(Constants.MONEDA_DOLAR) && montoActual > 200)
                {
                    throw new Exception(Constants.MENSAJE_LIMITE_DOLAR);
                }

                if (transaccion.Moneda.Equals(Constants.MONEDA_REAL) && montoActual > 300)
                {
                    throw new Exception(Constants.MENSAJE_LIMITE_REAL);
                }

                _context.Transaccion.Add(transaccion);
                await _context.SaveChangesAsync();

                return new Response<Transaccion>()
                {
                    Success = true,
                    Data = transaccion,
                    Message = Constants.MENSAJE_SUCCESS
                };
            }
            catch (Exception ex)
            {
                return new Response<Transaccion>()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
