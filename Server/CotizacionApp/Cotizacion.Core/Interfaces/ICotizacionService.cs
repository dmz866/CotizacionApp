using CotizacionApp.Core.Entities;
using System.Threading.Tasks;
namespace CotizacionApp.Core.Interfaces
{
    public interface ICotizacionService
    {
        Task<Response<Cotizacion>> GetCotizacion(string moneda);
        Task<Response<Transaccion>> ComprarMoneda(Transaccion transaccion);
    }
}
