using BeierholmWPF.Commands;
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
        private double[] dataField = new double[3];
        public double[] DataField
        {
            get { return dataField; }
            set
            {
                dataField = value;
                OnPropertyChanged();
            }
        }
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

        public void SetDataFieldsByCVR(string cvr, DateTime? startDate, DateTime? endDate)
        {
            EIncome = null;
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (evm.CVR == int.Parse(cvr))
                {
                    if (startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd)
                    {
                        EIncome = evm;
                    }
                }
            }
        }

        public void SetDataFieldsByCustomerID(string customerID, DateTime? startDate, DateTime? endDate)
        {
            EIncome = null;
            foreach (CustomerViewModel cvm in Customers)
            {
                if (cvm.GetCustomerID() == int.Parse(customerID))
                {
                    foreach (EIncome eincome in cvm.EIncomes)
                    {
                        if (startDate <= eincome.PeriodStart && endDate >= eincome.PeriodEnd)
                        {
                            EIncome = new EIncomeViewModel(eincome);
                        }
                    }
                }
            }
        }

        public List<EIncomeViewModel> GetEIncomes(string CVR, DateTime? startDate, DateTime? endDate)
        {
            List<EIncomeViewModel> sortedEIncome = new List<EIncomeViewModel>();
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (evm.CVR == int.Parse(CVR))
                {
                    if (startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd)
                    {
                        sortedEIncome.Add(evm);
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
