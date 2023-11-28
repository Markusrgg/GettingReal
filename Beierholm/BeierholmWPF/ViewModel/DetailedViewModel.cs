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
        public double DataField1 { get; set; }

        private double dataField2;
        public double DataField2
        {
            get { return dataField2; }
            set
            {
                dataField2 = value;
                OnPropertyChanged();
            }
        }
        public double DataField3 { get; set; }
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
                    //if (evm.PeriodStart == startDate && evm.PeriodEnd == endDate)
                    //{
                    //    DataField1 = evm.Fields["Feltnr0013"];
                    //    DataField2 = evm.Fields["Feltnr0014"];
                    //    DataField3 = evm.Fields["Feltnr0015"];
                    //}

                    if (startDate <= evm.PeriodStart && endDate >= evm.PeriodEnd)
                    {
                        DataField[0] = evm.Fields["0013"];
                        DataField2 = evm.Fields["0013"];
                        DataField3 = evm.Fields["0015"];
                        break;
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
