using CotizacionApp.Core.Entities;
using CotizacionApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CotizacionApp.Controllers
{
    public class CotizacionController : Controller
    {
        private readonly ICotizacionService _cotizacionService;
        public CotizacionController(ICotizacionService cotizacionService)
        {
            _cotizacionService  = cotizacionService;
        }
        [HttpGet]
        [Route("/api/cotizacion")]
        public async Task<Response<Cotizacion>> GetCotizacion(string moneda)
        {
            Response<Cotizacion> result = await _cotizacionService.GetCotizacion(moneda);
            return result;
        }
        [HttpPost]
        [Route("/api/compra")]
        public async Task<Response<Transaccion>> ComprarMoneda(Transaccion transaccion)
        {
            Response<Transaccion> result = await _cotizacionService.ComprarMoneda(transaccion);
            return result;
        }
    }
}
