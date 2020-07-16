using CotizacionApp.Core.Entities;
using CotizacionApp.Core.Interfaces;
using CotizacionCore.Entities;
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
            Response<Cotizacion> cotizacion = await _cotizacionService.GetCotizacion(moneda);
            return cotizacion;
        }
    }
}
