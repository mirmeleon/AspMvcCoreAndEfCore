namespace CarDealer.Models.Customers
{
    using CarDealer.Services.Models;
    using System.Collections.Generic;

    public class AllCustomersModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public OrderType OrderDirection { get; set; }
    }
}
