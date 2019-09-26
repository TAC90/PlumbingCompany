using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingCompany.Models
{
    public class Job
    {
        public Job()
        {
            this.Employees = new HashSet<Employee>();
            this.Parts = new HashSet<Part>();
        }
        [Key]
        public int JobId { get; set; }
        public Customer Customer { get; set; }
        public int Status { get; set; }
        public string Details { get; set; }
        public string WorkDetails { get; set; }
        public float HoursWorked { get; set; }
        public float TotalPrice { get; set; }
        public System.DateTime? DateAdded { get; set; }
        public System.DateTime? DateTarget { get; set; }
        public System.DateTime? DateClosed { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Part> Parts { get; set; }

    }
}
