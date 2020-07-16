using CotizacionApp.Core.Entities;
using CotizacionCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CotizacionApp.Core.Interfaces
{
    public interface ICotizacionService
    {
        Task<Response<Cotizacion>> GetCotizacion(string moneda);
    }
}
