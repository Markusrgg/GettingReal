using BeierholmWPF.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeierholmWPF.Model.EIncomes
{
    public class EIncomeRepository //26550688
    {
        private List<EIncome> eIncomes { get; set; } = new List<EIncome>();

        public EIncomeRepository()
        {
        }

        public List<EIncome> GetEIncomes()
        {
            return eIncomes;
        }

        public void AddEIncome(EIncome income)
        {
            eIncomes.Add(income);
        }
    }
}
