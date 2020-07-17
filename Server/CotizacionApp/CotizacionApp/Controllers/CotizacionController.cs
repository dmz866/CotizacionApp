using CotizacionApp.Core.Entities;
using CotizacionApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CotizacionApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CotizacionController : Controller
    {
        private readonly ICotizacionService _cotizacionService;
        public CotizacionController(ICotizacionService cotizacionService)
        {
            _cotizacionService  = cotizacionService;
        }
        [HttpGet]
        [Route("GetCotizacion")]
        public async Task<Response<Cotizacion>> GetCotizacion(string moneda)
        {
            Response<Cotizacion> result = await _cotizacionService.GetCotizacion(moneda);
            return result;
        }
        [HttpPost]
        [Route("ComprarMoneda")]
        public async Task<Response<Transaccion>> ComprarMoneda([FromBody] Transaccion transaccion)
        {
            Response<Transaccion> result = await _cotizacionService.ComprarMoneda(transaccion);
            return result;
        }
    }
}
