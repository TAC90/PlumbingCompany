using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingCompany.Models
{
    public class Part
    {
        public Part()
        {
            this.Jobs = new HashSet<Job>();
        }
        [Key]
        public int PartId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

    }
}
