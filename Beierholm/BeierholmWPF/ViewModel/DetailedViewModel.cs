using BeierholmWPF.Model.EIncome;
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


        private EIncomeViewModel EIncome { get; set; }
        public ObservableCollection<EIncomeViewModel> EIncomes { get; set; } = new ObservableCollection<EIncomeViewModel>();
        private EIncomeRepository incomeRepository = new EIncomeRepository();

        public DetailedViewModel()
        {
            foreach (EIncome eIncome in incomeRepository.EIncomes)
            {
                EIncomes.Add(new EIncomeViewModel(eIncome));
            }
        }

        public void SetDataFields(string cvr, DateTime? startDate, DateTime? endDate)
        {
            foreach (EIncomeViewModel evm in EIncomes)
            {
                if (evm.CVR == int.Parse(cvr))
                {
                    if (startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd)
                    {
                        DataField[0] = evm.Fields["0013"];
                        DataField[1] = evm.Fields["0015"];
                        DataField[2] = evm.Fields["0016"];
                        break;
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
