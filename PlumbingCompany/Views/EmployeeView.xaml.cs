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
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        readonly CompanyContext context = new CompanyContext();
        readonly EmployeeController empControl = new EmployeeController();

        bool jobSwap = false;

        public EmployeeView()
        {
            InitializeComponent();
            
            LbEmployeeList.ItemsSource = empControl.FillEmployeeList(); //Load Employee list on creation
            CbEmpPrefix.ItemsSource = empControl.GetPrefixList(); //Fill prefix list
        }
        private void LbEmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbEmployeeList.SelectedItem != null)
            {
                JobController jobControl = new JobController();

                int id = (LbEmployeeList.SelectedItem as Viewmodels.EmployeeViewModel).EmpID; //Get Employee ID

                EmpViewer.DataContext = context.Employees.Find(id); //Fill binding data with Employee data found by this ID
                DgJobList.ItemsSource = jobControl.FillJobShortList(id); // Fill job list of employee with this ID
            }
        }


        private void BtSwapJobView_Click(object sender, RoutedEventArgs e)
        {
            if (jobSwap)
            {
                DgJobList.Visibility = Visibility.Visible;
                LbJobList.Visibility = Visibility.Hidden;
                jobSwap = false;
            }
            else
            {
                LbJobList.Visibility = Visibility.Visible;
                DgJobList.Visibility = Visibility.Hidden;
                jobSwap = true;
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
            if (LblEmployeeId.Content == null) //Is this a new employee?
            {
                if (MessageBox.Show($"Create new Employee {TbEmpFirstName.Text} {TbEmpLastName.Text}?", "Create New Employee", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    empControl.AddNewEmployee(this); //Add new Employee
                    LbEmployeeList.ItemsSource = empControl.FillEmployeeList(); //Rebuild list
                }
            }
            else //Existing employee
            {
                if (MessageBox.Show($"Update Employee {TbEmpFirstName.Text} {TbEmpLastName.Text}?", "Update Employee", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    empControl.UpdateEmployee(this); //Update Employee record
                    LbEmployeeList.ItemsSource = empControl.FillEmployeeList(); //Rebuild list
                }
            }
        }

        private void BtRemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmDelete = MessageBox.Show("Are you sure you want to remove " + (LbEmployeeList.SelectedItem as Viewmodels.EmployeeViewModel).EmpFullName + "?", "Delete Confirmation", MessageBoxButton.YesNo);
            if(confirmDelete == MessageBoxResult.Yes)
            {
                Console.WriteLine("Removed {0}",  (LbEmployeeList.SelectedItem as Viewmodels.EmployeeViewModel).EmpFullName);
                LbEmployeeList.ItemsSource = empControl.FillEmployeeList();
            }
        }
    }
}
