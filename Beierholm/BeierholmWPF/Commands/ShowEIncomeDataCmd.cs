using BeierholmWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            if (parameter is ListViewModel lvm)
            {
                //MessageBox.Show($"Field 0013: {lvm.SelectedItem.Fields["0013"]}\nField 0015: {lvm.SelectedItem.Fields["0015"]}\nField 0016: {lvm.SelectedItem.Fields["0016"]}");
            }
        }
    }
}
