using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeierholmWPF.Model.EIncome
{
    public class EIncomeRepository //26550688
    {
        public ObservableCollection<EIncome> eIncomes { get; set; } = new ObservableCollection<EIncome>();

        public ObservableCollection<EIncome> GetEincomes(string cvr)
        {
            ObservableCollection<EIncome> eIn = new ObservableCollection<EIncome>();

            foreach (EIncome income in eIncomes)
            {
                if (income.CVR == int.Parse(cvr))
                {
                    eIn.Add(income);
                } 
            }
            return eIn;
        }
    }
}
