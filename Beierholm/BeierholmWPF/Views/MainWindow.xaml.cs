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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeierholmWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListWindow listWindow;

        public MainViewModel mvm;

        public MainWindow()
        {
            InitializeComponent();

            mvm = new MainViewModel();
            DataContext = mvm;

            mvm.mainWindow = this;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfEmpty();
            mvm.textBox = sender as TextBox;
            DisableTextBoxes(mvm.textBox);
        }

        private void DisableTextBoxes(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                InputEIncome.IsEnabled = true;
                InputCustomerID.IsEnabled = true;
                InputStartDate.IsEnabled = true;
                InputEndDate.IsEnabled = true;
            }
            else // If the current textbox has text, disable all textboxes except the current one
            {
                InputEIncome.IsEnabled = (textBox == InputEIncome);
                InputCustomerID.IsEnabled = (textBox == InputCustomerID);
                InputStartDate.IsEnabled = (textBox == InputStartDate);
                InputEndDate.IsEnabled = (textBox == InputEndDate);
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
        }
     }
}
