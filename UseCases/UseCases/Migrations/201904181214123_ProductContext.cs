namespace EF_UseCases.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        SKU = c.Int(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SKU);
            
            CreateTable(
                "dbo.ProductWebInfo",
                c => new
                    {
                        SKU = c.Int(nullable: false),
                        ImageURL = c.String(),
                    })
                .PrimaryKey(t => t.SKU)
                .ForeignKey("dbo.Product", t => t.SKU)
                .Index(t => t.SKU);
            
            DropTable("dbo.Photograph");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Photograph",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ThumbnailBits = c.Binary(),
                        HighResolutionBits = c.Binary(),
                    })
                .PrimaryKey(t => t.PhotoId);
            
            DropForeignKey("dbo.ProductWebInfo", "SKU", "dbo.Product");
            DropIndex("dbo.ProductWebInfo", new[] { "SKU" });
            DropTable("dbo.ProductWebInfo");
            DropTable("dbo.Product");
        }
    }
}
