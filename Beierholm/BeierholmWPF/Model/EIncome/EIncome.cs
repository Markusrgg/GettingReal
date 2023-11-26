using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeierholmWPF.Model.EIncome
{
    public class EIncome
    {
        public int CVR {  get; set; }
        public string? Name { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime CreatedDate { get; set; }
        public Dictionary<string, double> Fields { get; set; } = new Dictionary<string, double>();


        public EIncome(int cvr) { 
            CVR = cvr;
        }

        public EIncome(int cvr, string name) : this(cvr)
        {
            this.Name = name;
        }

        public EIncome(int CVR, string name, DateTime periodStart, DateTime periodEnd, DateTime createdDate, Dictionary<string, double> fields) : this(CVR, name)
        {
            PeriodEnd = periodEnd;
            PeriodStart = periodStart;
            CreatedDate = createdDate;
            Fields = fields;
        }
    }
}
