using BeierholmWPF.Model.EIncome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace BeierholmWPF.ViewModel
{
    public class ListViewModel
    {
        private EIncomeRepository incomeRepository = new EIncomeRepository();
        private FileManager manager = new FileManager(Directory.GetCurrentDirectory + "../../../../../Data/");
        
        public ObservableCollection<EIncome> SelectedEIncomes { get; set; } = new ObservableCollection<EIncome>();
        public ObservableCollection<EIncome> EIncomes { get; set; } = new ObservableCollection<EIncome>();

        public EIncome SelectedItem { get; set; }

        public ListViewModel()
        {
            incomeRepository.EIncomes = manager.LoadData();
        }

        public void Search(string CVR)
        {
            SelectedEIncomes = incomeRepository.GetEIncomes(CVR);
        }
    }
}
