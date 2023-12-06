using BeierholmWPF.Model.EIncomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeierholmWPF.Model.Customers
{
    public class CustomerRepository
    {
        private List<Customer> customers = new List<Customer>();

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public Customer GetCustomer(int customerID)
        {
            foreach (Customer customer in customers)
            {
                if (customer.CustomerID == customerID)
                {
                    return customer;
                }
            }
            return null;
        }

        public void RemoveCostumer(Customer customer)
        {
            customers.Remove(customer);
        }

        public void AddCustomerEIncome(Customer customer, EIncome eIncome)
        {
            customer.EIncomes.Add(eIncome);
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }
    }
}
