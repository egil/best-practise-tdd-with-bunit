using System.Collections.Generic;
using Components.Customers;

namespace Tests.Customers
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private List<Customer> customers = new();
        
        public int LastCreatedId { get; private set; }

        public int Add(Customer customer)
        {
            LastCreatedId = LastCreatedId++;
            customers.Add(customer with
            {
                Id = LastCreatedId
            });
            return LastCreatedId;
        }

        public IEnumerable<Customer> GetAll()
            => customers;
    }
}
