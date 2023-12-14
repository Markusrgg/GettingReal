using System.Collections.Generic;

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
