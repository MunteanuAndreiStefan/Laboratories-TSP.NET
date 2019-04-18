using System.Data.Entity;

namespace EF_UseCases
{
    class BusinessContext2 : DbContext
    {
        public BusinessContext2()
            : base("name=BusinessContext2")
        {
        }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Business> Businnesses { get; set; }
        public virtual DbSet<eCommerce> ECommerces { get; set; }
        public virtual DbSet<Retail> Retails { get; set; }
    }
}
