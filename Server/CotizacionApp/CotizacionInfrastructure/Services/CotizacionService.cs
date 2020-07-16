using System.Net.Http;
using System.Threading.Tasks;
using CotizacionApp.Core.Entities;
using CotizacionApp.Core.Interfaces;
using CotizacionApp.Core.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using CotizacionCore.Entities;

namespace CotizacionApp.Infrastructure.Services
{
    public class CotizacionService : ICotizacionService
    {
        private HttpClient _client;
        public CotizacionService()
        {
            _client = new HttpClient();
        }
        public async Task<Response<Cotizacion>> GetCotizacion(string moneda)
        {
            try
            {
                if(string.IsNullOrEmpty(moneda) || !Constants.MONEDAS_ACEPTADAS_LIST.Contains(moneda.ToLower()))
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
    }
}
