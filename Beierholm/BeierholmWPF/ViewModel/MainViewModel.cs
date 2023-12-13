using BeierholmWPF.Commands;
using BeierholmWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BeierholmWPF.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ListViewModel lvm;
        public DetailedViewModel dvm;

        private string selectedText = "";
        public string? SelectedText {
            get { return selectedText; } 
            set
            {
                selectedText = value;
                OnPropertyChanged();
            }
        }

        public DateTime? SelectedStartDate { get; set; }
        public DateTime? SelectedEndDate { get; set; }
        public string? SelectedBox { get; set; }
        public string? Selected { get; set; }

        public ICommand ShowEIncome { get; set; } = new ShowEIncomeCmd();
        public ICommand ShowHistory { get; set; } = new ShowHistoryCmd();

        public MainViewModel(ListViewModel lvm, DetailedViewModel dvm)
        {
            this.lvm = lvm;
            this.dvm = dvm;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
