using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeierholmWPF
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

        public EIncome(int cVR, string name, DateTime periodStart, DateTime periodEnd, DateTime createdDate, Dictionary<string, double> fields) : this(cVR, name)
        {
            PeriodEnd = periodEnd;
            CreatedDate = createdDate;
            Fields = fields;
        }
    }
}
