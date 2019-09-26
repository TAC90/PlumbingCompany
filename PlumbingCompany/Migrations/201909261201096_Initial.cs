namespace PlumbingCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Photo = c.String(),
                        Address = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Mail = c.String(),
                        PhoneNumber = c.String(),
                        MobilePhone = c.String(),
                        AddedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Details = c.String(),
                        WorkDetails = c.String(),
                        HoursWorked = c.Single(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                        DateAdded = c.DateTime(),
                        DateTarget = c.DateTime(),
                        DateClosed = c.DateTime(),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Prefix = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                        Photo = c.String(),
                        Address = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Mail = c.String(),
                        PhoneNumber = c.String(),
                        MobilePhone = c.String(),
                        HiredOn = c.DateTime(),
                        FiredOn = c.DateTime(),
                        AddedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PartId);
            
            CreateTable(
                "dbo.EmployeeJobs",
                c => new
                    {
                        Employee_EmployeeId = c.Int(nullable: false),
                        Job_JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeId, t.Job_JobId })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.Job_JobId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Job_JobId);
            
            CreateTable(
                "dbo.PartJobs",
                c => new
                    {
                        Part_PartId = c.Int(nullable: false),
                        Job_JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Part_PartId, t.Job_JobId })
                .ForeignKey("dbo.Parts", t => t.Part_PartId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.Job_JobId, cascadeDelete: true)
                .Index(t => t.Part_PartId)
                .Index(t => t.Job_JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartJobs", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.PartJobs", "Part_PartId", "dbo.Parts");
            DropForeignKey("dbo.EmployeeJobs", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.EmployeeJobs", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Jobs", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.PartJobs", new[] { "Job_JobId" });
            DropIndex("dbo.PartJobs", new[] { "Part_PartId" });
            DropIndex("dbo.EmployeeJobs", new[] { "Job_JobId" });
            DropIndex("dbo.EmployeeJobs", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Jobs", new[] { "Customer_CustomerId" });
            DropTable("dbo.PartJobs");
            DropTable("dbo.EmployeeJobs");
            DropTable("dbo.Parts");
            DropTable("dbo.Employees");
            DropTable("dbo.Jobs");
            DropTable("dbo.Customers");
        }
    }
}
