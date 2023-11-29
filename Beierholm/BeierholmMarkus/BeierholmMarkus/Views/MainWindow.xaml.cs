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
using BeierholmMarkus.ViewModels;
using BeierholmMarkus.Views;

namespace BeierholmMarkus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mvm;
        private ListWindow listWindow;

        public MainWindow()
        {
            InitializeComponent();

            mvm = new MainViewModel();
        }

        private void ShowEIncome_Click(object sender, RoutedEventArgs e)
        {
            listWindow = new ListWindow();

            this.Close();
            listWindow.ShowDialog();
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            listWindow = new ListWindow();

            this.Close();
            listWindow.ShowDialog();

        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfEmpty();

            TextBox? textBox = sender as TextBox;
            if (textBox != null)
            {
                listWindow.ResultLabel.Content = "Resultat for søgt: " + textBox.Text;
            }
        }

        private void CheckIfEmpty()
        {
            if (InputEIncome.Text != ""
                || InputCustomerID.Text != ""
                || InputStartDate.Text != ""
                || InputEndDate.Text != "")
            {
                ShowEIncome.IsEnabled = true;
                HistoryButton.IsEnabled = true;
            }
            else
            {
                ShowEIncome.IsEnabled = false;
                HistoryButton.IsEnabled = false;
            }


            //DOESN'T WORK?!?!?!?! vvvvvvv


            //Make other fields non-typeable

            //InputEIncome
            if (InputEIncome.Text.Length > 0)
            {
                InputCustomerID.IsEnabled = false;
                InputStartDate.IsEnabled = false;
                InputEndDate.IsEnabled = false;
            }
            else
            {
                InputCustomerID.IsEnabled = true;
                InputStartDate.IsEnabled = true;
                InputEndDate.IsEnabled = true;
            }

            //InputCustomerID
            if (InputCustomerID.Text.Length > 0)
            {
                InputEIncome.IsEnabled = false;
                InputStartDate.IsEnabled = false;
                InputEndDate.IsEnabled = false;
            }
            else
            {
                InputEIncome.IsEnabled = true;
                InputStartDate.IsEnabled = true;
                InputEndDate.IsEnabled = true;
                InputCustomerID.IsEnabled = true;
            }

            //InputStartDate
            if (InputStartDate.Text.Length > 0)
            {
                InputEIncome.IsEnabled = false;
                InputCustomerID.IsEnabled = false;
                InputEndDate.IsEnabled = false;
            }
            else
            {
                InputEIncome.IsEnabled = true;
                InputCustomerID.IsEnabled = true;
                InputEndDate.IsEnabled = true;
                InputStartDate.IsEnabled = true;
            }

            //InputEndDate
            if (InputEndDate.Text.Length > 0)
            {
                InputEIncome.IsEnabled = false;
                InputCustomerID.IsEnabled = false;
                InputStartDate.IsEnabled = false;
            }
            else
            {
                InputEIncome.IsEnabled = true;
                InputCustomerID.IsEnabled = true;
                InputStartDate.IsEnabled = true;
            }
        }
    }
}
