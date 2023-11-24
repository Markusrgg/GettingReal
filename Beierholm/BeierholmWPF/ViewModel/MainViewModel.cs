using BeierholmWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BeierholmWPF.ViewModel
{
    public class MainViewModel
    {
        public ListViewModel lvm;

        public string? SelectedText { get; set; }
        public string? SelectedBox { get; set; }
        public string? Selected { get; set; }

        public ICommand ShowEIncome { get; set; } = new ShowEIncomeCmd();
        public ICommand ShowHistory { get; set; } = new ShowHistoryCmd();

        public MainViewModel(ListViewModel listView)
        {
            lvm = listView;
        }
    }
}
