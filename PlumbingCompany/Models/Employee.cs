using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingCompany.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Jobs = new HashSet<Job>();
        }
        [Key]
        public int EmployeeId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime? DateOfBirth { get; set; }
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? HiredOn { get; set; }
        public DateTime? FiredOn { get; set; }

        public virtual ICollection<Job> Jobs {get;set;}

    }
}
