using System.Data.Entity;

namespace EF_UseCases
{
    class BusinessContext : DbContext
    {
        public BusinessContext()
            : base("name=BusinessContext")
        {
        }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Business> Businnesses { get; set; }
        public virtual DbSet<eCommerce> ECommerces { get; set; }
        public virtual DbSet<Retail> Retails { get; set; }
    }
}
