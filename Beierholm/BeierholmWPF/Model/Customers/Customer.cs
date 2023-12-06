using BeierholmWPF.Model.EIncomes;
using BeierholmWPF.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace BeierholmWPF.Model.Customers
{
    public class Customer
    {
        public string? Name { get; set; }
        public int CVR { get; set; }
        public int CustomerID { get; set; }
        public BusinessType BusinessType { get; set; }
        public List<EIncome> EIncomes { get; set; } = new List<EIncome>();

        public Customer(string name)
        {
            Name = name;
        }

        public Customer(string name, int customerID, int cvr, BusinessType type) : this(name)
        {
            CustomerID = customerID;
            CVR = cvr;
            BusinessType = type;
        }
    }
}
