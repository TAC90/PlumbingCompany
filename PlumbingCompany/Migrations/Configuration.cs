namespace PlumbingCompany.Migrations
{
    using PlumbingCompany.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PlumbingCompany.CompanyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PlumbingCompany.CompanyContext";
        }

        protected override void Seed(PlumbingCompany.CompanyContext context)
        {
            context.Employees.AddOrUpdate(new Employee() { EmployeeId = 0, Prefix = "Mr.", FirstName = "Mario", LastName = "Mario", Address = "Pipehouse Av 1", City = "Mushroom City", Country = "Mushroom Kingdom", Mail = "Mari0Number1@MKingdom.com", ZipCode = "1981 SM", PhoneNumber = "718 555-0709", DateOfBirth = new DateTime(1990, 11, 21), Photo = "../Img/Employees/01_Mario.png", AddedOn = DateTime.Now });
            context.Employees.AddOrUpdate(new Employee() { EmployeeId = 1, Prefix = "Mr.", FirstName = "Luigi", LastName = "Mario", Address = "Pipehouse Av 2", City = "Mushroom City", Country = "Mushroom Kingdom", Mail = "Weegee@MKingdom.com", ZipCode = "1981 SM", PhoneNumber = "718 555-0714", DateOfBirth = new DateTime(1990, 11, 21), Photo = "../Img/Employees/09_Luigi.png", AddedOn = DateTime.Now });
            context.Employees.AddOrUpdate(new Employee() { EmployeeId = 2, Prefix = "Mr.", FirstName = "Bowser", LastName = "King", Address = "Koopalane 1", City = "Underground Lair", Country = "Dinosaur Land", Mail = "T3hR34lK1ngK00p4@MKingdom.com", ZipCode = "1985 KK", PhoneNumber = "718 555-0714", DateOfBirth = new DateTime(1985, 9, 13), Photo = "../Img/Employees/14_Bowser.png", AddedOn = DateTime.Now });
            context.Employees.AddOrUpdate(new Employee() { EmployeeId = 3, Prefix = "Mr.", FirstName = "Green", LastName = "Yoshi", Address = "Eggerlane 36251", City = "Yoshi's Island", Country = "Dinosaur Land", Mail = "Y00000shi@MKingdom.com", ZipCode = "1990 DL", DateOfBirth = new DateTime(1990, 11, 21), Photo = "../Img/Employees/05_Yoshi.png", AddedOn = DateTime.Now });

            context.Customers.AddOrUpdate(new Customer() { CustomerId = 0, FirstName = "Mushroom Sewers", Address = "Pipehouse Av 17", City = "Mushroom City", Country = "Mushroom Kingdom", ZipCode = "1981 PP", Mail = "PlumbingTroubles@MKingdom.com", PhoneNumber = "922", AddedOn = DateTime.Now });
            context.Customers.AddOrUpdate(new Customer() { CustomerId = 1, FirstName = "Pipeworks", Address = "Industry Av 2", City = "Mushroom City", Country = "Mushroom Kingdom", ZipCode = "1980 KY", Mail = "PlumbingTroubles@MKingdom.com", PhoneNumber = "718 505-9801", AddedOn = DateTime.Now });
            context.Customers.AddOrUpdate(new Customer() { CustomerId = 2, FirstName = "Princess", LastName = "Daisy", Address = "Royal Boulevard", City = "Mushroom City", Country = "Mushroom Kingdom", ZipCode = "1989 GY", Mail = "FlowerPrincess113@MKingdom.com", PhoneNumber = "718 505-0102", AddedOn = DateTime.Now });

            context.JobStatuses.AddOrUpdate(new JobStatus { Id = 0, Name = "On Hold" });
            context.JobStatuses.AddOrUpdate(new JobStatus { Id = 1, Name = "Working On" });
            context.JobStatuses.AddOrUpdate(new JobStatus { Id = 2, Name = "Wait on Response" });
            context.JobStatuses.AddOrUpdate(new JobStatus { Id = 3, Name = "Aborted" });
            context.JobStatuses.AddOrUpdate(new JobStatus { Id = 4, Name = "Finished" });


            context.SaveChanges();
            var emp = context.Employees.ToList();
            var cli = context.Customers.ToList();

            context.Jobs.AddOrUpdate(new Job() {JobId = 0, Status = 1, Details = "Clean the pipes", DateAdded = new DateTime(2019, 9, 16), Employees = new HashSet<Employee> { emp[0], emp[3] }, Customer = cli[0], DateTarget = DateTime.Now.AddDays(7) });
            context.Jobs.AddOrUpdate(new Job() {JobId = 1, Status = 1, Details = "Deliver pipes to Volcano Island", DateAdded = new DateTime(2019, 9, 16), Employees = new HashSet<Employee> { emp[2] }, Customer = cli[1], DateTarget = DateTime.Now.AddDays(4) });
            context.Jobs.AddOrUpdate(new Job() {JobId = 2, Status = 0, Details = "Water the Piranha Plants", DateAdded = new DateTime(2019, 10, 16), Employees = new HashSet<Employee> { emp[1] }, Customer = cli[2], DateTarget = DateTime.Now.AddDays(-14) });

            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
