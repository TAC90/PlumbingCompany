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
        CompanyContext context = new CompanyContext();
        
        bool jobSwap = false;
        public EmployeeView()
        {
            InitializeComponent();


            EmployeeController empControl = new EmployeeController(); //Construct Controller

            LbEmployeeList.ItemsSource = empControl.FillEmployeeList();

            //List<JobList> jobList = new List<JobList>
            //{
            //    new JobList() { JobId = 0, JobDetails = "Clear Piranha Plants from pipes.", JobLocation = "Peach's Castle", JobWorker = "Mario Mario", JobDateStart = "28/09/2019"},
            //    new JobList() { JobId = 1, JobDetails = "Stomp Goombas", JobLocation = "Dinosaur Land", JobWorker = "Luigi Mario", JobDateStart = "6/09/2019"}
            //};

            //LbJobList.ItemsSource = jobList;

            //DgJobList.ItemsSource = jobList;
        }
        private void LbEmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbEmployeeList.SelectedItem != null)
            {
                int id = (LbEmployeeList.SelectedItem as EmployeeController.EmployeeViewModel).EmpID; //Get Employee ID
                
                EmpViewer.DataContext = context.Employees.Find(id);
                //context.Employees.Include(a => a.Jobs).Where(b => b.EmployeeId == id);

                var f = context.Jobs.Where(a => a.Employees.Where(b => b.EmployeeId == id).Any(c => c != null)).ToList(); //Not working yet. Likely due to a list of items being placed in a datacontext, foreach?

                List<Job> jobList = new List<Job>();
                foreach (var empJobs in f)
                {
                    //build list of jobs
                }
                LbJobList.DataContext = f;
            }
        }

        private void LbJobList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        }
    }
}
