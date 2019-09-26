using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingCompany.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Jobs = new HashSet<Job>();
        }
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? AddedOn { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
        [NotMapped]
        public string FullName { get
            {
                return $"{FirstName} {LastName}";
            } }
    }
}
