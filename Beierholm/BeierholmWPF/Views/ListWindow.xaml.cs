using BeierholmWPF.ViewModel;
using System.Windows;

namespace BeierholmWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        private ListViewModel lvm;
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
