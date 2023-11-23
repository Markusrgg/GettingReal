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

namespace BeierholmWPF
{
    public class ListViewModel
    {
        private EIncomeRepository incomeRepository = new EIncomeRepository();
        private FileManager manager = new FileManager(Directory.GetCurrentDirectory + "../../../../../Data/");
        
        public ObservableCollection<EIncome> Selected { get; set; } = new ObservableCollection<EIncome>();
        public ObservableCollection<EIncome> eIncomes { get; set; } = new ObservableCollection<EIncome>();

        public ListViewModel()
        {
            incomeRepository.eIncomes = manager.LoadData();
        }

        public void Search(string CVR)
        {
            Selected = incomeRepository.GetEincomes(CVR);
        }
    }
}
