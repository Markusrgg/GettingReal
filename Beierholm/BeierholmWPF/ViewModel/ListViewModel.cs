using BeierholmWPF.Commands;
using BeierholmWPF.Model.Customers;
using BeierholmWPF.Model.EIncomes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace BeierholmWPF.ViewModel
{
    public class ListViewModel
    {
        private FileManager fm = new FileManager();

        public ObservableCollection<EIncomeViewModel> SelectedEIncomes { get; set; } = new ObservableCollection<EIncomeViewModel>();
        public ObservableCollection<EIncomeViewModel> EIncomes { get; set; } = new ObservableCollection<EIncomeViewModel>();
        public ObservableCollection<CustomerViewModel> Customers { get; set; } = new ObservableCollection<CustomerViewModel>();

        public EIncomeViewModel SelectedItem { get; set; }

        public ListViewModel()
        {
            foreach (Customer customer in fm.CustomerRepository.GetCustomers())
            {
                foreach (EIncome eIncome in customer.EIncomes)
                {
                    EIncomes.Add(new EIncomeViewModel(eIncome));
                }
                Customers.Add(new CustomerViewModel(customer));
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

        public void SetSelectedEIncomes(string CVR, DateTime? startDate, DateTime? endDate)
        {
            SelectedEIncomes.Clear();
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (int.Parse(CVR) == evm.CVR && startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd)
                {
                    SelectedEIncomes.Add(evm);
                }
            }
        }

        public void SetSelectedEIncomes(DateTime? startDate, DateTime? endDate)
        {
            SelectedEIncomes.Clear();
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd)
                {
                    SelectedEIncomes.Add(evm);
                }
            }
        }

        public ICommand ShowEIncomeData { get; set; } = new ShowEIncomeDataCmd();
    }
}
