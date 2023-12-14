using BeierholmWPF.Commands;
using BeierholmWPF.Model;
using BeierholmWPF.Model.Customers;
using BeierholmWPF.Model.EIncomes;
using System;
using System.Collections.ObjectModel;
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

            if (input.Length > 0)
            {
                Customer c = fm.CustomerRepository.GetCustomer(u.StringToInt(input));
                foreach (EIncomeViewModel evm in EIncomes)
                {
                    if (evm.CVR == u.StringToInt(input) ||
                        c != null && evm.CVR == c.CVR)
                    {
                        SelectedEIncomes.Add(evm);
                        outcome = true;
                    }
                }
            }
            return outcome;
        }

        public bool SetSelectedEIncomes(string input, DateTime? startDate, DateTime? endDate)
        {
            bool outcome = false;
            SelectedEIncomes.Clear();
            if (input.Length > 0)
            {
                Customer c = fm.CustomerRepository.GetCustomer(u.StringToInt(input));
                foreach (EIncomeViewModel evm in EIncomes)
                {
                    if (c != null && evm.CVR == c.CVR && startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd ||
                        u.StringToInt(input) == evm.CVR && startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd)
                    {
                        SelectedEIncomes.Add(evm);
                        outcome = true;
                    }
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
