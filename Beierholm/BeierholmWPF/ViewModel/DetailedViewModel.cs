using BeierholmWPF.Commands;
using BeierholmWPF.Model;
using BeierholmWPF.Model.Customers;
using BeierholmWPF.Model.EIncomes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BeierholmWPF.ViewModel
{
    public class DetailedViewModel : INotifyPropertyChanged
    {
        private Utility utility = new Utility();
        //private double[] dataField = new double[3];
        //public double[] DataField
        //{
        //    get { return dataField; }
        //    set
        //    {
        //        dataField = value;
        //        OnPropertyChanged();
        //    }
        //}
        public ICommand Download { get; set; } = new DownloadCmd();
        public ICommand DownloadPDF { get; set; } = new DownloadPDFCmd();

        public EIncomeViewModel EIncome { get; set; }
        public ObservableCollection<EIncomeViewModel> EIncomes { get; set; } = new ObservableCollection<EIncomeViewModel>();
        public ObservableCollection<CustomerViewModel> Customers { get; set; } = new ObservableCollection<CustomerViewModel>();

        private FileManager fm = new FileManager();

        public DetailedViewModel()
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

        public bool SetDataFields(string input, DateTime? startDate, DateTime? endDate)
        {
            bool outcome = false;
            EIncome = null;
            Customer c = fm.CustomerRepository.GetCustomer(utility.StringToInt(input));
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (evm.CVR == int.Parse(input) ||
                    c != null && evm.CVR == c.CVR)
                {
                    if (startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd)
                    {
                        EIncome = evm;
                        outcome = true;
                    }
                }
            }
            return outcome;
        }

        public List<EIncomeViewModel> GetEIncomes(string CVR, DateTime? startDate, DateTime? endDate)
        {
            List<EIncomeViewModel> sortedEIncome = new List<EIncomeViewModel>();
            foreach (CustomerViewModel cvm in Customers) 
            {
                if (cvm.CVR == utility.StringToInt(CVR) || cvm.GetCustomerID() == utility.StringToInt(CVR))
                {
                    foreach (EIncome e in cvm.EIncomes)
                    {
                        if (startDate <= e.PeriodStart && endDate >= e.PeriodEnd)
                        {
                            EIncomeViewModel evm = new EIncomeViewModel(e);
                            sortedEIncome.Add(evm);
                        }
                    }
                }
            }
            return sortedEIncome;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
