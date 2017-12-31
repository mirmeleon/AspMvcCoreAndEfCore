namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using System.Collections.Generic;

   public interface ICustomerService
    {
       IEnumerable<CustomerModel> OrderedCustomers(OrderType order);
    }
}
