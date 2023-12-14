using BeierholmWPF.ViewModel;
using System;
using System.Windows.Input;

namespace BeierholmWPF.Commands
{
    public class ShowEIncomeDataCmd : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object? parameter)
        {
            bool result = true;
            if (parameter is ListViewModel lvm)
            {
                if (lvm.SelectedItem == null)
                {
                    result = false;
                }
            }
            return result;
        }

        public void Execute(object? parameter)
        {
        }
    }
}
