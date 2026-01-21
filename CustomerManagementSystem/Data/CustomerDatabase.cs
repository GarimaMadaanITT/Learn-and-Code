using System.Collections.Generic;
using CustomerManagement.Models;

namespace CustomerManagement.Data
{
    public static class CustomerDatabase
    {
        public static List<Customer> Customers { get; } = new List<Customer>
        {
            new Customer{ CustomerID = 1, CompanyName="Microsoft", ContactName="Satya", Country="India"},
            new Customer{ CustomerID = 2, CompanyName="In Time Tec", ContactName="Jeet", Country="USA"},
            new Customer{ CustomerID = 3, CompanyName="IttRacknap", ContactName="Munesh", Country="India"}
        };
    }
}
