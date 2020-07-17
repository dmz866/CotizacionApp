using Microsoft.EntityFrameworkCore;
using CotizacionApp.Core.Entities;

namespace CotizacionApp.Infrastructure.Data
{
    public class CotizacionAppContext : DbContext
    {
        public CotizacionAppContext()
        {
        }
        public CotizacionAppContext(DbContextOptions<CotizacionAppContext> options) : base(options)
        {
        }
        public virtual DbSet<Transaccion> Transacciones { get; set; }
        public virtual DbSet<LookUp> LookUp { get; set; }
    }
}
