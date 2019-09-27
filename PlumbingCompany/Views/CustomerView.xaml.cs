using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.Entity;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlumbingCompany;
using PlumbingCompany.Controllers;
using PlumbingCompany.Models;

namespace PlumbingCompany.Views
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        readonly CompanyContext context = new CompanyContext();
        readonly CustomerController cusControl = new CustomerController();

        public CustomerView()
        {
            InitializeComponent();

            LbCustomerList.ItemsSource = cusControl.FillCustomerList(); //Load Customer list on creation
        }
        private void LbCustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbCustomerList.SelectedItem != null)
            {
                JobController jobControl = new JobController();

                int id = (LbCustomerList.SelectedItem as Viewmodels.CustomerViewModel).CusID; //Get Customer ID

                CustomerViewer.DataContext = context.Customers.Find(id); //Fill binding data with Customer data found by this ID
                DgJobList.ItemsSource = jobControl.FillJobShortList(id); // Fill job list of cliloyee with this ID
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void BtSaveForm_Click(object sender, RoutedEventArgs e)
        {
            if (LblCustomerId.Content == null) //Is this a new Customer?
            {
                if (MessageBox.Show($"Create new Customer {TbCusFirstName.Text} {TbCusLastName.Text}?", "Create New", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    cusControl.AddNewCustomer(this); //Add new Customer
                    LbCustomerList.ItemsSource = cusControl.FillCustomerList(); //Rebuild list
                }
            }
            else //Existing Customer
            {
                if (MessageBox.Show($"Create new Customer {TbCusFirstName.Text} {TbCusLastName.Text}?", "Create New", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    cusControl.UpdateCustomer(this); //Update Customer record
                    LbCustomerList.ItemsSource = cusControl.FillCustomerList(); //Rebuild list
                }
            }
        }

        private void BtRemoveCustomer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmDelete = MessageBox.Show("Are you sure you want to remove " + (LbCustomerList.SelectedItem as Viewmodels.CustomerViewModel).CusFullName + "?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (confirmDelete == MessageBoxResult.Yes)
            {
                Console.WriteLine("Removed {0}", (LbCustomerList.SelectedItem as Viewmodels.CustomerViewModel).CusFullName);
                LbCustomerList.ItemsSource = cusControl.FillCustomerList();
            }
        }
    }
}
