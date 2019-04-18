namespace EF_UseCases.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("BusinessContext.eCommerce", "BusinessId", "BusinessContext.Business");
            DropForeignKey("BusinessContext.Retail", "BusinessId", "BusinessContext.Business");
            DropIndex("BusinessContext.eCommerce", new[] { "BusinessId" });
            DropIndex("BusinessContext.Retail", new[] { "BusinessId" });
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Salary = c.Decimal(precision: 18, scale: 2),
                        Wage = c.Decimal(precision: 18, scale: 2),
                        EmployeeType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            DropTable("BusinessContext.Business");
            DropTable("BusinessContext.eCommerce");
            DropTable("BusinessContext.Retail");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.BusinessId);
            
            CreateTable(
                "BusinessContext.eCommerce",
                c => new
                    {
                        BusinessId = c.Int(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.BusinessId);
            
            CreateTable(
                "BusinessContext.Business",
                c => new
                    {
                        BusinessId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LicenseNumber = c.String(),
                    })
                .PrimaryKey(t => t.BusinessId);
            
            DropTable("dbo.Employees");
            CreateIndex("BusinessContext.Retail", "BusinessId");
            CreateIndex("BusinessContext.eCommerce", "BusinessId");
            AddForeignKey("BusinessContext.Retail", "BusinessId", "BusinessContext.Business", "BusinessId");
            AddForeignKey("BusinessContext.eCommerce", "BusinessId", "BusinessContext.Business", "BusinessId");
        }
    }
}
