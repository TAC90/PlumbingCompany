namespace PlumbingCompany.Migrations
{
    using PlumbingCompany.Models;
    using System;
    using System.Data.Entity;
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
            context.Employees.Add(new Employee() { FirstName = "Bowser", LastName = "King", Address = "Koopalane 1", City = "Underground Lair", Country = "Dinosaur Land", Mail = "T3hR34lK1ngK00p4@MKingdom.com", ZipCode = "1985 KK", DateOfBirth = new DateTime(1985, 9, 13), ProfilePicture = "../Img/Employees/14_Bowser.png" });
            context.Employees.Add(new Employee() { FirstName = "Green", LastName = "Yoshi", Address = "Eggerlane 36251", City = "Yoshi's Island", Country = "Dinosaur Land", Mail = "Y00000shi@MKingdom.com", ZipCode = "1990 DL", DateOfBirth = new DateTime(1990, 11, 21), ProfilePicture = "../Img/Employees/05_Yoshi.png" });

            context.Jobs.Add(new Job() { Status = 1, Details = "Clean the pipes", Location = "Sewers", DateAdded = new DateTime(2019, 9, 16) });
            context.Jobs.Add(new Job() { Status = 0, Details = "Water the Piranha Plants", Location = "Donut Plains", DateAdded = new DateTime(2019, 10, 16) });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
