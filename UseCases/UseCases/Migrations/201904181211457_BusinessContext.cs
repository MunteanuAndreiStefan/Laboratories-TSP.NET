namespace EF_UseCases.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusinessContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "BusinessContext.Business",
                c => new
                    {
                        BusinessId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LicenseNumber = c.String(),
                    })
                .PrimaryKey(t => t.BusinessId);
            
            CreateTable(
                "BusinessContext.eCommerce",
                c => new
                    {
                        BusinessId = c.Int(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.BusinessId)
                .ForeignKey("BusinessContext.Business", t => t.BusinessId)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "BusinessContext.Retail",
                c => new
                    {
                        BusinessId = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZIPCode = c.String(),
                    })
                .PrimaryKey(t => t.BusinessId)
                .ForeignKey("BusinessContext.Business", t => t.BusinessId)
                .Index(t => t.BusinessId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("BusinessContext.Retail", "BusinessId", "BusinessContext.Business");
            DropForeignKey("BusinessContext.eCommerce", "BusinessId", "BusinessContext.Business");
            DropIndex("BusinessContext.Retail", new[] { "BusinessId" });
            DropIndex("BusinessContext.eCommerce", new[] { "BusinessId" });
            DropTable("BusinessContext.Retail");
            DropTable("BusinessContext.eCommerce");
            DropTable("BusinessContext.Business");
        }
    }
}
