using BeierholmWPF.Model;
using BeierholmWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BeierholmWPF.Commands
{
    public class ShowHistoryCmd : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            bool result = false;
            if (parameter is MainViewModel mvm)
            {
                bool isInt = false;
                if (mvm?.SelectedText != null || mvm?.SelectedText != "")
                {
                    result = true;
                }
                if (mvm?.SelectedStartDate != null && mvm?.SelectedEndDate != null)
                {
                    result = true;
                }
            }
            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                switch (mvm.SelectedBox)
                {
                    case "InputEIncome":
                    case "InputCustomerID":
                    case "InputStartDate":
                    case "InputEndDate":
                        bool check = mvm.lvm.SetSelectedEIncomes(mvm.SelectedText);
                        if (!check)
                        {
                            string s = mvm.SelectedBox == "InputEIncome" ? "CVR" : "Kundenr";
                            if (mvm.SelectedText.Length < 8 && s == "CVR")
                            {
                                MessageBox.Show("Et CVR har 8 tal");
                            }
                            else
                            {
                                MessageBox.Show($"{s}: '{mvm.SelectedText}' findes ikke i systemet");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
