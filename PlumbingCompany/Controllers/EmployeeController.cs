using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlumbingCompany;
using PlumbingCompany.Models;
using PlumbingCompany.Views;

namespace PlumbingCompany.Controllers
{
    public class EmployeeController
    {
        public List<EmployeeViewModel> FillEmployeeList()
        {
            DateTime d = DateTime.Now; // Get current date

            List<EmployeeViewModel> empList = new List<EmployeeViewModel> //Create new list of class type to populate with db data
            {
                new EmployeeViewModel()
            }; 

            using (var context = new CompanyContext()) //Access db
            {
                List<Employee> employees = context.Employees.Where(a => a.FiredOn > d || a.FiredOn == null).ToList(); //Find all records of employees still active in company from db, put in list

                foreach (var emp in employees) //Go through all employees in list
                {
                    EmployeeViewModel listedEmployees = new EmployeeViewModel(emp.EmployeeId, emp.FirstName, emp.LastName, emp.ProfilePicture); //Convert db data to class data
                    empList.Add(listedEmployees); //Populate list
                }
            }
            return empList; //Return list to called method
        }
        public void AddNewEmployee(EmployeeView employee)
        {
            using (var context = new CompanyContext())
            {
                Employee emp = new Employee
                {
                    FirstName = employee.TbEmpFirstName.Text,
                    LastName = employee.TbEmpLastName.Text,
                    Address = employee.TbEmpAddress.Text


                };
                context.Employees.Add(emp);
            }
        }

        public class EmployeeViewModel
        {
            public EmployeeViewModel()
            {
                EmpFullName = "New Employee";
                EmpImg = "../Img/Employees/00_Default.png";
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
