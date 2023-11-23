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
        public ListWindow? listWindow;
        public MainWindow? mainWindow;

        public TextBox? textBox;

        public string? Selected { get; set; }

        public ICommand ShowEIncome { get; set; } = new ShowEIncomeCmd();

        public ICommand ShowHistory { get; set; } = new ShowHistoryCmd();

    }
}
