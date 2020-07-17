using CotizacionApp.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CotizacionApp.Core.Interfaces
{
    public interface IUtilsService
    {
        Task<IEnumerable<LookUp>> GetMonedasAceptadas();
    }
}
