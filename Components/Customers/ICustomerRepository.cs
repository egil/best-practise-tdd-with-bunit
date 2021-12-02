using System.Collections.Generic;

namespace Components.Customers;

public interface ICustomerRepository
{
    /// <summary>
    /// Adds a new customer to the repository. 
    /// The new customer will be assigned a unique ID when added.
    /// </summary>
    /// <param name="customer">The customer to add.</param>
    /// <returns>The customers unique ID.</returns>
    int Add(Customer customer);

    /// <summary>
    /// Returns all customers in the repository.
    /// </summary>
    IEnumerable<Customer> GetAll();
}
