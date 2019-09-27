using PlumbingCompany.Models;
using PlumbingCompany.Viewmodels;
using PlumbingCompany.Views;
using System;
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

        internal void AddNewJob(JobView job)
        {
            using (var context = new CompanyContext())
            {
                Job tempJob = new Job
                {
                    JobStatus = job.CbJobStatus.SelectedItem as JobStatus,
                    Customer = job.CbJobClient.SelectedItem as Customer,
                    Details = job.TbJobDetails.Text,
                    HoursWorked = Convert.ToInt32( job.TbJobHours.Text),
                    WorkDetails = job.TbJobWorkDetails.Text
                    //HiredOn = customer.TbCusHiredOn.SelectedDate,
                };
                Console.WriteLine($"Adding: {job.CbJobClient.SelectedValue} task as new Job"); //Log change
                context.Jobs.Add(tempJob);
                context.SaveChanges();
            }
        }


        internal void UpdateEmployee(JobView jobView)
        {
            using (var context = new CompanyContext())
            {


#if DEBUG
                Console.WriteLine($"Updating record"); //Log change
#endif
                context.SaveChanges();
            }
        }
    }
}
