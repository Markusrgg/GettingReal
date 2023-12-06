using BeierholmWPF.Commands;
using BeierholmWPF.Model;
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
        private Utility u = new Utility();

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

        public bool SetSelectedEIncomes(string input) //26550688
        {
            bool outcome = false;
            SelectedEIncomes.Clear();

            Customer c = fm.CustomerRepository.GetCustomer(u.StringToInt(input));
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (evm.CVR == int.Parse(input) ||
                    c != null && evm.CVR == c.CVR)
                {
                    SelectedEIncomes.Add(evm);
                    outcome = true;
                }
            }
            return outcome;
        }

        public bool SetSelectedEIncomes(string input, DateTime? startDate, DateTime? endDate)
        {
            bool outcome = false;
            SelectedEIncomes.Clear();
            Customer c = fm.CustomerRepository.GetCustomer(u.StringToInt(input));
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (c != null && evm.CVR == c.CVR && startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd || 
                    int.Parse(input) == evm.CVR && startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd)
                {
                    SelectedEIncomes.Add(evm);
                    outcome = true;
                }
            }
            return outcome;
        }

        public bool SetSelectedEIncomes(DateTime? startDate, DateTime? endDate)
        {
            bool outcome = false;
            SelectedEIncomes.Clear();
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd)
                {
                    SelectedEIncomes.Add(evm);
                    outcome = true;
                }
            }
            return outcome;
        }

        public ICommand ShowEIncomeData { get; set; } = new ShowEIncomeDataCmd();
    }
}
