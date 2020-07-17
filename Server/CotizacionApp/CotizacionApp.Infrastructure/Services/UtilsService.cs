using CotizacionApp.Core.Entities;
using CotizacionApp.Core.Interfaces;
using CotizacionApp.Core.Utils;
using CotizacionApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionApp.Infrastructure.Services
{
    public class UtilsService : IUtilsService
    {
        private readonly CotizacionAppContext _context;
        public UtilsService(CotizacionAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LookUp>> GetMonedasAceptadas()
        {
            var monedasAceptadas = await _context.LookUp
                                                .Where(l => l.Group.Equals(Constants.MONEDA_GROUP))
                                                .ToListAsync();
            return monedasAceptadas;
        }
    }
}
