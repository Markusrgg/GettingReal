using BeierholmWPF.Model.Customers;
using BeierholmWPF.Model.EIncomes;
using System.Collections.Generic;

namespace BeierholmWPF.ViewModel
{
    public class CustomerViewModel
    {
        private Customer customer;
        public string? Name { get; set; }
        public int CVR { get; set; }
        public List<EIncome> EIncomes { get; set; } = new List<EIncome>();

        public CustomerViewModel(Customer customer)
        {
            this.customer = customer;
            Name = customer.Name;
            CVR = customer.CVR;
            EIncomes = customer.EIncomes;
        }

        public Customer GetCustomer(CustomerRepository repo, int ID)
        {
            return repo.GetCustomer(ID);
        }

        public int GetCustomerID()
        {
            return customer.CustomerID;
        }
    }
}
