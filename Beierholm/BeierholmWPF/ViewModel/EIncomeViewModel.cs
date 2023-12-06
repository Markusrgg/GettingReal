using BeierholmWPF.Model.EIncomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeierholmWPF.ViewModel
{
    public class EIncomeViewModel
    {
        private EIncome EIncome { get; set; }
        public int CVR { get; set; }
        public string? Name { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime CreatedDate { get; set; }
        public Dictionary<string, double> Fields { get; set; } = new Dictionary<string, double>();

        public EIncomeViewModel(EIncome eIncome)
        {
            this.EIncome = eIncome;
            CVR = eIncome.CVR;
            Name = eIncome.Name;
            PeriodStart = eIncome.PeriodStart;
            PeriodEnd = eIncome.PeriodEnd;
            CreatedDate = eIncome.CreatedDate;
            Fields = eIncome.Fields;
        }
    }
}
