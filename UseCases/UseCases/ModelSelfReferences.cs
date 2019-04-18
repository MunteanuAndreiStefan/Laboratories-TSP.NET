namespace EF_UseCases
{
    using System.Data.Entity;
    public class ModelSelfRefrences : DbContext
    {
        public ModelSelfRefrences()
            : base("name=ModelSelfRefrences")
        {
        }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<SelfReference> SelfReferences { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SelfReference>()
                .HasMany(m => m.References)
                .WithOptional(m => m.ParentSelfReference);
        }
    }
}