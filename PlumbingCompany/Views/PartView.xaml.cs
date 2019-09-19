using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PlumbingCompany.Views
{
    /// <summary>
    /// Interaction logic for PartView.xaml
    /// </summary>
    public partial class PartView : UserControl
    {
        public PartView()
        {
            InitializeComponent();
            List<PartList> partList = new List<PartList>
            {
                new PartList() { PartId = 0, PartName = "Shoes", PartPrice = "$10.00", PartStock = "7"},
                new PartList() { PartId = 1, PartName = "Overalls", PartPrice = "$65.00", PartStock = "2"}
            };
            LbPartList.ItemsSource = partList;
        }

        private void LbPartList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbPartList.SelectedItem != null)
            {
                Console.WriteLine((LbPartList.SelectedItem as PartList).PartId);
            }
        }
    }


    public class PartList
    {
        public int PartId { get; set; }
        public string PartName { get; set; }
        public string PartStock { get; set; }
        public string PartPrice { get; set; }
    }

}

