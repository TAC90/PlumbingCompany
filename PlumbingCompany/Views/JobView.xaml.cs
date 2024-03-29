﻿using PlumbingCompany.Controllers;
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

namespace PlumbingCompany.Views
{
    /// <summary>
    /// Interaction logic for JobView.xaml
    /// </summary>
    public partial class JobView : UserControl
    {
        readonly CompanyContext context = new CompanyContext();
        readonly JobController jobControl = new JobController();

        public JobView()
        {
            InitializeComponent();

            LbJobList.ItemsSource = jobControl.FillJobList();
            CbJobStatus.ItemsSource = context.JobStatuses.ToList();
        }

        private void LbJobList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbJobList.SelectedItem != null)
            {
                int id = (LbJobList.SelectedItem as JobController.JobViewModel).JobId; //Get Job ID

                JobViewer.DataContext = context.Jobs.Find(id); //Fill binding data with Job data found by this ID
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
    }
}
