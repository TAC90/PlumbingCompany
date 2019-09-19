using PlumbingCompany.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingCompany
{

    public class CompanyContext : DbContext
    {
        //public CompanyContext() : base("DefaultConnection")
        //{

        //}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Part> Parts { get; set; }

    }
}
