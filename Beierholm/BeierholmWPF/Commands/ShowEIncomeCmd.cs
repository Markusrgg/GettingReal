using BeierholmWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BeierholmWPF.Commands
{
    public class ShowEIncomeCmd : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            bool result = true;
            if (parameter is MainViewModel mvm)
            {
                if (mvm?.SelectedStartDate == null || mvm?.SelectedStartDate == null)
                {
                    result = false;
                }
                if (mvm?.SelectedEndDate == null || mvm?.SelectedEndDate == null)
                {
                    result = false;
                }
                if (mvm?.SelectedText == null || mvm.SelectedText == "")
                {
                    result = false;
                } else
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
            if (parameter is MainViewModel mvm) {
                switch (mvm.SelectedBox)
                {
                    case "InputEIncome":
                        if (mvm?.SelectedStartDate == null || mvm?.SelectedEndDate == null)
                        {
                            if (mvm?.SelectedText != null)
                            {
                                mvm.lvm.SetSelectedEIncomes(mvm.SelectedText);
                            }
                        } else
                        {
                            if (mvm.SelectedText != null)
                            {
                                mvm.dvm.SetDataFields(mvm.SelectedText, mvm.SelectedStartDate, mvm.SelectedEndDate);
                            }
                        }
                        break;
                    case "InputCustomerID":
                        break;
                    //case "InputStartDate":
                    //    break;
                    //case "InputEndDate":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
