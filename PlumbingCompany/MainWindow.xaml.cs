using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlumbingCompany.Models;
using PlumbingCompany.Viewmodels;

namespace PlumbingCompany
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDB();
        }

        
        public void InitializeDB() //Start Database
        {
            using (var context = new CompanyContext())
            {
                Console.WriteLine("Current entry amount: " + context.Employees.Count());
                context.SaveChanges();
                Console.WriteLine("New entry amount: " + context.Employees.Count());
            }
        }

        private void BtEmployeeView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EmployeeViewModel();
        }

        private void BtPartView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new PartViewModel();
        }

        private void BtJobView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new JobViewModel();
        }

        private void BtCustomerView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CustomerViewModel();
        }
    }
}
