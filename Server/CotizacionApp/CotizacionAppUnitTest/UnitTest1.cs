using CotizacionApp.Core.Utils;
using CotizacionApp.Infrastructure.Data;
using CotizacionApp.Infrastructure.Services;
using NUnit.Framework;

namespace CotizacionAppUnitTest
{
    public class Tests
    {
        CotizacionAppContext _context;
        UtilsService _utilsService;
        CotizacionService _cotizacionService;
        [SetUp]
        public void Setup()
        {
            _context = new CotizacionAppContext();
            _utilsService = new UtilsService(_context);
            _cotizacionService = new CotizacionService(_context, _utilsService);
        }

        [Test]
        public void TestGetMonedasAceptadas()
        {            
            var result = _utilsService.GetMonedasAceptadas();
            Assert.IsNotNull(result);
        }
        [Test]
        public void TestGetCotizacion()
        {
            var result = _cotizacionService.GetCotizacion(Constants.MONEDA_DOLAR);
            Assert.IsNotNull(result);
        }
    }
}