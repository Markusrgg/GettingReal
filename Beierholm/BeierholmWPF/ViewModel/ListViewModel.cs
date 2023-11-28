using BeierholmWPF.Model.EIncome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
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
        //  private FileManager manager = new FileManager(Directory.GetCurrentDirectory + "../../../../../Data/");

        public ObservableCollection<EIncomeViewModel> SelectedEIncomes { get; set; } = new ObservableCollection<EIncomeViewModel>();
        public ObservableCollection<EIncomeViewModel> EIncomes { get; set; } = new ObservableCollection<EIncomeViewModel>();

        public EIncomeViewModel SelectedItem { get; set; }

        public ListViewModel() {
            foreach (EIncome eIncome in incomeRepository.EIncomes)
            {
                EIncomes.Add(new EIncomeViewModel(eIncome));
            }
        }

        public void SetSelectedEIncomes(string CVR) //26550688
        {
            SelectedEIncomes.Clear();
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (evm.CVR == int.Parse(CVR))
                {
                    SelectedEIncomes.Add(evm);
                }
            }
        }
    }
}
