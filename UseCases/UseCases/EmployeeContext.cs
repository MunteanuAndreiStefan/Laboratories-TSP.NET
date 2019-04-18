using System.Data.Entity;

namespace EF_UseCases
{
    class EmployeeContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Map<FulTimeEmployee>(m =>
                    m.Requires("EmployeeType").HasValue(1))
                .Map<HourlyEmployee>(m =>
                    m.Requires("EmployeeType").HasValue(2));
        }

    }
}
