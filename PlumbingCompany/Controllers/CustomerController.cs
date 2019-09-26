using PlumbingCompany.Models;
using PlumbingCompany.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlumbingCompany.Controllers
{
    public class CustomerController
    {
        public List<CustomerViewModel> FillCustomerList()
        {
            List<CustomerViewModel> customerList = new List<CustomerViewModel> { new CustomerViewModel() };//Create new list of class type to populate with db data
            using (var context = new CompanyContext()) //Access db
            {
                List<Customer> customers = context.Customers.ToList(); //Find all records of customers still active in company from db, put in list

                foreach (var customer in customers) //Go through all customers in list
                {
                    CustomerViewModel listedCustomers = new CustomerViewModel(customer.CustomerId, customer.FirstName, customer.LastName, customer.Photo); //Convert db data to class data
                    customerList.Add(listedCustomers); //Populate list
                }
            }
            return customerList; //Return list to called method
        }

        public void AddNewCustomer(CustomerView customer)
        {
            using (var context = new CompanyContext())
            {
                Customer tempCustomer = new Customer
                {
                    FirstName = customer.TbCusFirstName.Text,
                    LastName = customer.TbCusLastName.Text,
                    Address = customer.TbCusAddress.Text,
                    ZipCode = customer.TbCusZipCode.Text,
                    City = customer.TbCusCity.Text,
                    Country = customer.TbCusCountry.Text,
                    Mail = customer.TbCusMail.Text,
                    PhoneNumber = customer.TbCusPhone.Text,
                    MobilePhone = customer.TbCusMobile.Text,
                    //HiredOn = customer.TbCusHiredOn.SelectedDate,
                };
                Console.WriteLine($"Adding: {tempCustomer.FirstName} {tempCustomer.LastName} as new Customer"); //Log change
                context.Customers.Add(tempCustomer);
                context.SaveChanges();
            }
        }
        public void UpdateCustomer(CustomerView customer)
        {
            using (var context = new CompanyContext())
            {
                Customer tempCustomer = context.Customers.Find(customer.LblCustomerId.Content);
                tempCustomer.FirstName = customer.TbCusFirstName.Text;
                tempCustomer.LastName = customer.TbCusLastName.Text;
                tempCustomer.Address = customer.TbCusAddress.Text;
                tempCustomer.ZipCode = customer.TbCusZipCode.Text;
                tempCustomer.City = customer.TbCusCity.Text;
                tempCustomer.Country = customer.TbCusCountry.Text;
                tempCustomer.Mail = customer.TbCusMail.Text;
                tempCustomer.PhoneNumber = customer.TbCusPhone.Text;
                tempCustomer.MobilePhone = customer.TbCusMobile.Text;
                //customer.FiredOn = customer.TbCusFiredOn;
#if DEBUG
                Console.WriteLine($"Updating: {tempCustomer.FirstName} {tempCustomer.LastName}'s record"); //Log change
#endif
                context.SaveChanges();
            }
        }
        public class CustomerViewModel
        {
            public CustomerViewModel()
            {
                CusFullName = "New Customer";
                CusImg = "../Img/Customers/00_Default.png";
            }

            public CustomerViewModel(int cusId, string firstName, string lastName, string cusImg)
            {
                this.CusID = cusId;
                this.CusFullName = $"{firstName} {lastName}";
                this.CusImg = cusImg;
            }

            public int CusID { get; set; }
            public string CusFullName { get; set; }
            public string CusActiveJobs { get; set; }
            public string CusImg { get; set; }
        }
    }
}
