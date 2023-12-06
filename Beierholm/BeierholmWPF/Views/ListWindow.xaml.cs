using BeierholmWPF.ViewModel;
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
using System.Windows.Shapes;

namespace BeierholmWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        public ListViewModel lvm;
        private DetailedWindow detailedWindow;
        private DetailedViewModel dvm;

        public ListWindow(ListViewModel lvm)
        {
            this.lvm = lvm;
            dvm = new DetailedViewModel();

            InitializeComponent();
         
            this.DataContext = lvm;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ShowEIncomeData_Click(object sender, RoutedEventArgs e)
        {
            if (lvm.SelectedItem != null) 
            {

                detailedWindow = new DetailedWindow(dvm);

                detailedWindow.ResultLabel.Content = "Resultat for søgt: " + lvm.SelectedItem.CVR;
                dvm.SetDataFields(lvm.SelectedItem.CVR.ToString(), lvm.SelectedItem.PeriodStart, lvm.SelectedItem.PeriodEnd);

                detailedWindow.ShowDialog();

            }
        }
    }
}
