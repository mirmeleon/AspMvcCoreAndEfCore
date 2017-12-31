namespace CarDealer.Services
{
    using Data;
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    using System.Linq;

    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext db;

        public CustomerService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<CustomerModel> OrderedCustomers(OrderType order)
        {
            var customerQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderType.Ascending:
                    customerQuery = customerQuery.OrderBy(c => c.BirthDate)
                        .ThenBy(c=>c.Name);
                    break;
                case OrderType.Descending:
                    customerQuery = customerQuery
                        .OrderByDescending(c => c.BirthDate)
                         .ThenBy(c => c.Name);
                    break;

                default:
                    throw new System.InvalidOperationException("Invalid order direction");
                    break;
            }

            return customerQuery
                .Select(c => new CustomerModel  //mapping without automapper
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

                }
    }
}
