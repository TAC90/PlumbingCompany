using PlumbingCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingCompany.Controllers
{
    class JobController
    {
        public List<JobShortViewModel> FillJobShortList(int id)
        {
            List<JobShortViewModel> jobList = new List<JobShortViewModel>();
            using (var context = new CompanyContext())
            {
                List<Job> jobs = context.Jobs.Where(a => a.Employees.Where(b => b.EmployeeId == id).Any(c => c != null)).ToList();
                foreach (var job in jobs)
                {
                    List<string> jobWorkers= new List<string>();
                    foreach (var emp in job.Employees)
                    {
                        jobWorkers.Add(emp.FirstName + " " + emp.LastName);
                    }
                    
                    JobShortViewModel listedJob = new JobShortViewModel(job.JobId, job.DateAdded, job.Location, jobWorkers, job.Details);
                    jobList.Add(listedJob);
                }
            }
            return jobList;
        }


    }
    public class JobShortViewModel
    {
        public JobShortViewModel()
        {

        }
        public JobShortViewModel(int id, DateTime? dateStart, string location, List<string> workers, string details)
        {
            this.JobID = id;
            this.JobDateStart = dateStart;
            this.JobLocation = location;
            this.JobWorkers = string.Join(", ", workers);
            if (details.Length > 50)
            {
                details = details.Substring(0, 47) + "...";
            }
            this.JobDetails = details;
        }
        public int JobID { get; set; }
        public DateTime? JobDateStart { get; set; }
        public string JobLocation { get; set; }
        public string JobWorkers { get; set; }
        public string JobDetails { get; set; }
    }
}
