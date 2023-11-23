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
    public class ShowHistoryCmd : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
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
