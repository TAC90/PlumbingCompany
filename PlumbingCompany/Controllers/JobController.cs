using PlumbingCompany.Models;
using PlumbingCompany.Viewmodels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PlumbingCompany.Controllers
{
    public class JobController
    {
        public List<JobViewModel> FillJobList()
        {
            List<JobViewModel> jobList = new List<JobViewModel>();
            using (var context = new CompanyContext())
            {
                List<Job> jobs = context.Jobs.Include("Employees").Include("Customer").ToList();
                foreach (var job in jobs)
                {
                    JobViewModel listedJob = new JobViewModel(job.JobId, job.Customer, job.DateAdded, job.Employees, job.Details);
                    jobList.Add(listedJob);
                }
            }
            return jobList;
        }
        public List<JobShortViewModel> FillJobShortList(int id)
        {
            List<JobShortViewModel> jobList = new List<JobShortViewModel>();
            using (var context = new CompanyContext())
            {
                List<Job> jobs = context.Jobs.Include("Customer").Where(a => a.Employees.Where(b => b.EmployeeId == id).Any(c => c != null)).ToList();
                foreach (var job in jobs)
                {
                    List<string> jobWorkers = new List<string>();
                    foreach (var emp in job.Employees)
                    {
                        jobWorkers.Add($"{emp.FirstName} {emp.LastName}");
                    }
                    JobShortViewModel listedJob = new JobShortViewModel(job.JobId, job.Customer, job.DateAdded, job.DateTarget, job.Employees, job.Details);
                    jobList.Add(listedJob);
                }
            }
            return jobList;
        }

        public class JobViewModel
        {
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

        public class JobShortViewModel
        {
            public JobShortViewModel(int id, Customer customer, DateTime? dateAdded, DateTime? dateTarget, ICollection<Employee> employees, string details)
            {
                this.JobId = id;
                this.ClientFullName = $"{customer.FirstName} {customer.LastName}";
                this.JobDateAdded = dateAdded;
                this.JobDateTarget = dateTarget;

                List<string> tempEmp = new List<string>();
                foreach (Employee employee in employees)
                {
                    tempEmp.Add(employee.FullName);
                }
                this.JobEmployees = string.Join(", ", employees);

                if (details.Length > 50)
                {
                    details = details.Substring(0, 47) + "...";
                }
                this.JobDetails = details;
            }
            public int JobId { get; set; }
            public string ClientFullName { get; set; }
            public DateTime? JobDateAdded { get; set; }
            public DateTime? JobDateTarget { get; set; }
            public string JobEmployees { get; set; }
            public string JobDetails { get; set; }
        }
    }
}
