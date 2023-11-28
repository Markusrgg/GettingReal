using BeierholmWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        private DetailedWindow detailedWindow;

        private ListViewModel lvm;
        private MainViewModel mvm;
        private DetailedViewModel dvm;

        public MainWindow()
        {
            InitializeComponent();

            lvm = new ListViewModel();
            dvm = new DetailedViewModel();
            mvm = new MainViewModel(lvm, dvm);
            DataContext = mvm;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            mvm.SelectedText = textBox?.Text;
            mvm.SelectedBox = textBox?.Name;

            DisableTextBoxes(textBox);
        }

        private void DisableTextBoxes(TextBox? textBox)
        {
            if (string.IsNullOrEmpty(textBox?.Text))
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
                //InputStartDate.IsEnabled = (textBox == InputStartDate);
                //InputEndDate.IsEnabled = (textBox == InputEndDate);
            }
        }

        private void ShowEIncome_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.SelectedText != null && mvm.SelectedText != "")
            {
                if (InputStartDate.Text != "" && InputEndDate.Text != "")
                {
                    detailedWindow = new DetailedWindow(dvm);

                    detailedWindow.ResultLabel.Content = "Resultat for søgt: " + mvm.SelectedText;

                    mvm.ShowEIncome.Execute(mvm);

                    detailedWindow.ShowDialog();
                }
                else
                {
                    listWindow = new ListWindow(lvm);
                    listWindow.ResultLabel.Content = "Resultat for søgt: " + mvm.SelectedText;

                    mvm.ShowEIncome.Execute(mvm);

                    listWindow.ShowDialog();
                }
            }
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.SelectedText != null && mvm.SelectedText != "")
            {
                listWindow = new ListWindow(lvm);
                listWindow.ResultLabel.Content = "Resultat for søgt: " + mvm.SelectedText;

                mvm.ShowHistory.Execute(mvm);

                listWindow.ShowDialog();
            }
        }

        private void InputStartDateSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            mvm.SelectedStartDate = InputStartDate.SelectedDate;
        }

        private void InputEndDateSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            mvm.SelectedEndDate = InputEndDate.SelectedDate;
        }
    }
}
