using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PlumbingCompany;
using PlumbingCompany.Models;
using PlumbingCompany.Viewmodels;
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
                    int c = emp.Jobs.Count;
                    EmployeeViewModel listedEmployees = new EmployeeViewModel(emp.EmployeeId, emp.FirstName, emp.LastName, c, emp.Photo); //Convert db data to class data
                    empList.Add(listedEmployees); //Populate list
                }
            }
            return empList; //Return list to called method
        }

        internal IEnumerable GetPrefixList()
        {
            List<string> prefixes = new List<string> { "Mr.", "Ms.", "Mrs.", "Miss" };
            return prefixes;
        }

        public void AddNewEmployee(EmployeeView employee)
        {
            using (var context = new CompanyContext())
            {
                Employee emp = new Employee
                {
                    Prefix = employee.CbEmpPrefix.Text,
                    FirstName = employee.TbEmpFirstName.Text,
                    LastName = employee.TbEmpLastName.Text,
                    DateOfBirth = employee.DpEmpDateOfBirth.SelectedDate,
                    Address = employee.TbEmpAddress.Text,
                    ZipCode = employee.TbEmpZipCode.Text,
                    City = employee.TbEmpCity.Text,
                    Country = employee.TbEmpCountry.Text,
                    Mail = employee.TbEmpMail.Text,
                    PhoneNumber = employee.TbEmpPhone.Text,
                    MobilePhone = employee.TbEmpMobile.Text,
                    //HiredOn = employee.TbEmpHiredOn.SelectedDate,
                };
                Console.WriteLine("Adding: " + emp.FirstName + " " + emp.LastName + " as new Employee"); //Log change
                context.Employees.Add(emp);
                context.SaveChanges();
            }
        }
        public void UpdateEmployee(EmployeeView employee)
        {
            using (var context = new CompanyContext())
            {
                Employee emp = context.Employees.Find(employee.LblEmployeeId.Content);
                emp.Prefix = employee.CbEmpPrefix.Text;
                emp.FirstName = employee.TbEmpFirstName.Text;
                emp.LastName = employee.TbEmpLastName.Text;
                emp.DateOfBirth = employee.DpEmpDateOfBirth.SelectedDate;
                emp.Address = employee.TbEmpAddress.Text;
                emp.ZipCode = employee.TbEmpZipCode.Text;
                emp.City = employee.TbEmpCity.Text;
                emp.Country = employee.TbEmpCountry.Text;
                emp.Mail = employee.TbEmpMail.Text;
                emp.PhoneNumber = employee.TbEmpPhone.Text;
                emp.MobilePhone = employee.TbEmpMobile.Text;
                //emp.FiredOn = employee.TbEmpFiredOn;
                Console.WriteLine("Updating: " + emp.FirstName + " " + emp.LastName + "'s record"); //Log change

                context.SaveChanges();
            }
        }
    }
}
