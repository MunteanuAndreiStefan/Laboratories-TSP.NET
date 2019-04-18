using System.Data.Entity;

namespace EF_UseCases
{
    public class PhotographContext : DbContext
    {
        public PhotographContext()
            : base("name=PhotographContext")
        {
        }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Photograph> Photographs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Photograph>()
                .HasRequired(p => p.PhotographFullImage)
                .WithRequiredPrincipal(p => p.Photograph);
            modelBuilder.Entity<Photograph>().ToTable("Photograph");
            modelBuilder.Entity<PhotographFullImage>().
                ToTable("Photograph");
        }
    }
}
