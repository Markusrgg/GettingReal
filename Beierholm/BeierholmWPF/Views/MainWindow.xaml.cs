using BeierholmWPF.Model;
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
            mvm.SelectedBox = textBox?.Name;

            string final = "";
            foreach (char c in textBox.Text)
            {
                if (Char.IsDigit(c))
                {
                    final += c;
                } else
                {
                    string error = "Forkert input. Kun tal accepteret.";
                    MessageBox.Show(error);
                }
            }
            if (final.Length > 8 && textBox.Name == "InputEIncome")
            {
                final = textBox.Text.Substring(0, 8);
                mvm.SelectedText = final;
                MessageBox.Show("Forkert input! Maks. 8 tal er accepteret.");
            } else if (final.Length > 3 && textBox.Name == "InputCostumerID")
            {
                final = textBox.Text.Substring(0, 3);
                mvm.SelectedText = final;
                MessageBox.Show("Forkert input! Maks. 3 tal er accepteret.");
            }
            mvm.SelectedText = final;
            textBox.Text = final;
            textBox.Select(textBox.Text.Length, 0);

            DisableTextBoxes(textBox);
        }

        private void DisableTextBoxes(TextBox? textBox)
        {
            if (string.IsNullOrEmpty(textBox?.Text))
            {
                InputEIncome.IsEnabled = true;
                InputCostumerID.IsEnabled = true;
                InputStartDate.IsEnabled = true;
                InputEndDate.IsEnabled = true;
            }
            else // If the current textbox has text, disable all textboxes except the current one
            {
                InputEIncome.IsEnabled = (textBox == InputEIncome);
                InputCostumerID.IsEnabled = (textBox == InputCostumerID);
                //InputStartDate.IsEnabled = (textBox == InputStartDate);
                //InputEndDate.IsEnabled = (textBox == InputEndDate);
            }
        }

        private void ShowEIncome_Click(object sender, RoutedEventArgs e)
        {
            bool check = true;
            if (mvm.SelectedText != null && mvm.SelectedText != "")
            {
                if (InputStartDate.Text != "" && InputEndDate.Text != "")
                {
                    int count = dvm.GetEIncomes(mvm.SelectedText, mvm.SelectedStartDate, mvm.SelectedEndDate).Count;
                    if (count == 1)
                    {
                        check = false;
                        detailedWindow = new DetailedWindow(dvm);

                        detailedWindow.ResultLabel.Content = "Resultat for søgt: " + mvm.SelectedText;

                        mvm.ShowEIncome.Execute(mvm);

                        detailedWindow.ShowDialog();
                    }
                    if (count > 1)
                    {
                        check = false;
                        listWindow = new ListWindow(lvm);
                        listWindow.ResultLabel.Content = "Resultat for søgt: " + mvm.SelectedText;

                        mvm.ShowEIncome.Execute(mvm);

                        listWindow.ShowDialog();
                    }
                }
            }
            if (check && mvm.SelectedText == null || check && mvm?.SelectedText.Length < 1)
            {
                listWindow = new ListWindow(lvm);
                listWindow.ResultLabel.Content = $"Resultat for søgt: {mvm.SelectedStartDate} - {mvm.SelectedEndDate}";

                mvm.ShowEIncome.Execute(mvm);

                listWindow.ShowDialog();
                return;
            }
            if (mvm.SelectedText.Length > 0 && mvm.SelectedStartDate == null && mvm.SelectedEndDate == null)
            {
                listWindow = new ListWindow(lvm);
                listWindow.ResultLabel.Content = "Resultat for søgt: " + mvm.SelectedText;

                mvm.ShowEIncome.Execute(mvm);

                listWindow.ShowDialog();
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
            if (mvm.SelectedBox == null || mvm.SelectedBox == "")
            {
                mvm.SelectedBox = InputStartDate.Name;
            }
        }

        private void InputEndDateSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            mvm.SelectedEndDate = InputEndDate.SelectedDate;
            if (mvm.SelectedBox == null || mvm.SelectedBox == "")
            {
                mvm.SelectedBox = InputEndDate.Name;
            }
        }
    }
}
