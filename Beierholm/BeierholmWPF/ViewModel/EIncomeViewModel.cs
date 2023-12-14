using BeierholmWPF.Model.EIncomes;
using System;
using System.Collections.Generic;
using System.Data;

namespace BeierholmWPF.ViewModel
{
    public class EIncomeViewModel
    {
        private EIncome EIncome { get; set; }
        private Dictionary<string, double> Fields { get; set; } = new Dictionary<string, double>();
        public int CVR { get; set; }
        public string? Name { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime CreatedDate { get; set; }
        public DataTable DT { get; set; } = new DataTable();

        public EIncomeViewModel(EIncome eIncome)
        {
            this.EIncome = eIncome;
            CVR = eIncome.CVR;
            Name = eIncome.Name;
            PeriodStart = eIncome.PeriodStart;
            PeriodEnd = eIncome.PeriodEnd;
            CreatedDate = eIncome.CreatedDate;
            Fields = eIncome.Fields;

            CreateDataTable();
        }

        public void CreateDataTable()
        {
            int i = 0;
            double[] objects = new double[Fields.Count];
            DataRow row = DT.NewRow();
            foreach (var kv in EIncome.Fields)
            {
                DT.Columns.Add(kv.Key, typeof(string));
                row[i] = kv.Value;
                i++;
            }
            DT.Rows.Clear();
            DT.Rows.Add(row);
        }
    }
}
