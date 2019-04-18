namespace EF_UseCases.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotographContext : DbMigration
    {
        public override void Up()
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
            
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
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
            
            DropTable("dbo.Photograph");
        }
    }
}
