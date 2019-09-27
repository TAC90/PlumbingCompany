using PlumbingCompany.Models;
using System;
using System.Collections.Generic;

namespace PlumbingCompany.Viewmodels
{
    public class JobViewModel
    {
        public JobViewModel()
        {

        }
        public JobViewModel(int id, Customer customer, DateTime? dateTarget, ICollection<Employee> employees, string details)
        {
            JobId = id;
            ClientFullName = customer.FullName;
            JobDateTarget = dateTarget;
            List<string> tempEmp = new List<string>();
            foreach (Employee employee in employees)
            {
                tempEmp.Add(employee.FullName);
            }
            JobEmployees = string.Join(", ", tempEmp);

            if (details.Length > 50)
            {
                details = details.Substring(0, 47) + "...";
            }
            this.JobDetails = details;
        }
        public int JobId { get; set; }
        public string ClientFullName { get; set; }
        public DateTime? JobDateTarget { get; set; }
        public string JobEmployees { get; set; }
        public string JobDetails { get; set; }
    }
}
