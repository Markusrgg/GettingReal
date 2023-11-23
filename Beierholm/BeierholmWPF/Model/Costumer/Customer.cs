using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeierholmWPF
{
    public class Customer
    {
        public string? Name { get; set; }
        public int CVR { get; set; }

        public BusinessType BusinessType { get; set; }
        public Adress? Adresse { get; set; }
    }
}
