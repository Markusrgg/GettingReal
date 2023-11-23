using BeierholmWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //if (parameter is MainViewModel mvm)
            //{
            //    if (mvm.mainWindow != null && mvm.textBox != null)
            //    {
            //        if (string.IsNullOrEmpty(mvm.textBox.Text))
            //        {
            //            mvm.mainWindow.InputEIncome.IsEnabled = true;
            //            mvm.mainWindow.InputCustomerID.IsEnabled = true;
            //            mvm.mainWindow.InputStartDate.IsEnabled = true;
            //            mvm.mainWindow.InputEndDate.IsEnabled = true;
            //        }
            //        else // If the current textbox has text, disable all textboxes except the current one
            //        {
            //            mvm.mainWindow.InputEIncome.IsEnabled = (mvm.textBox == mvm.mainWindow.InputEIncome);
            //            mvm.mainWindow.InputCustomerID.IsEnabled = (mvm.textBox == mvm.mainWindow.InputCustomerID);
            //            mvm.mainWindow.InputStartDate.IsEnabled = (mvm.textBox == mvm.mainWindow.InputStartDate);
            //            mvm.mainWindow.InputEndDate.IsEnabled = (mvm.textBox == mvm.mainWindow.InputEndDate);
            //        }
            //    }
            //    else
            //    {
            //        result = false;
            //    }
            //}
            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                if (mvm.textBox != null)
                {
                    TextBox textBox = mvm.textBox;
                    mvm.listWindow = new ListWindow();
                    mvm.listWindow.ResultLabel.Content = "Resultat for søgt: " + textBox.Text;
                    mvm.listWindow.lvm.Search(textBox.Text);

                    if (mvm.mainWindow != null)
                    {
                        mvm.mainWindow.Close();
                    }

                    mvm.listWindow.ShowDialog();
                }
            }
        }
    }
}
