using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CotizacionApp.Core.Entities;
using CotizacionApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CotizacionApp.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UtilsController : Controller
    {
        private readonly IUtilsService _utilsService;
        public UtilsController(IUtilsService utilsService)
        {
            _utilsService = utilsService;
        }
        [HttpGet]
        [Route("GetMonedasAceptadas")]
        public async Task<IActionResult> GetMonedasAceptadas()
        {
            var monedasAceptadas = await _utilsService.GetMonedasAceptadas();
            return Ok(monedasAceptadas);
        }
    }
}
