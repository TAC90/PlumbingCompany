using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlumbingCompany;
using PlumbingCompany.Models;

namespace PlumbingCompany.Controllers
{
    public class EmployeeController
    {

        public List<EmployeeViewModel> FillEmployeeList()
        {
            DateTime d = DateTime.Now;

            List<EmployeeViewModel> empList = new List<EmployeeViewModel>();

            using (var context = new CompanyContext())
            {
                List<Employee> employees = context.Employees.Where(a => a.FiredOn > d || a.FiredOn == null).ToList();

                foreach (var emp in employees)
                {
                    EmployeeViewModel listedEmployees = new EmployeeViewModel(emp.EmployeeId, emp.FirstName, emp.LastName, emp.ProfilePicture);
                    empList.Add(listedEmployees);
                }
            }
            
            return empList;
        }
        public class EmployeeViewModel
        {
            public EmployeeViewModel()
            {

            }

            public EmployeeViewModel(int empId, string firstName, string lastName, string empImg)
            {
                this.EmpID = empId;
                this.EmpFullName = firstName + " " + lastName;
                this.EmpActiveJobs = "Active Jobs: ";
                this.EmpImg = empImg;
            }

            public int EmpID { get; set; }
            public string EmpFullName { get; set; }
            public string EmpActiveJobs { get; set; }
            public string EmpImg { get; set; }
        }
    }
}
