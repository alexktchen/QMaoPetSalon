using System.Data.Entity;
using QMaoPetSalon.Models;

namespace QMaoPetSalon.DbContexts
{
    /// <summary>
    /// Entity framework context
    /// </summary>
    public class QMaoPetSalonDataBase : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CouponType> CouponTypes { get; set; }
        public DbSet<PetVariety> PetVarietys { get; set; }

        public DbSet<DiseaseType> DiseaseTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

    }
}
