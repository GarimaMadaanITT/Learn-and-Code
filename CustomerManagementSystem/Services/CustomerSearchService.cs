using System.Collections.Generic;
using System.Linq;
using CustomerManagement.Models;
using CustomerManagement.Data;

namespace CustomerManagement.Services
{
    public class CustomerSearchService
    {
        public List<Customer> SearchByCountry(string country)
        {
            return CustomerDatabase.Customers
                .Where(c => c.Country.Contains(country))
                .OrderBy(c => c.CustomerID)
                .ToList();
        }

        public List<Customer> SearchByCompanyName(string company)
        {
            return CustomerDatabase.Customers
                .Where(c => c.CompanyName.Contains(company))
                .OrderBy(c => c.CustomerID)
                .ToList();
        }

        public List<Customer> SearchByContact(string contact)
        {
            return CustomerDatabase.Customers
                .Where(c => c.ContactName.Contains(contact))
                .OrderBy(c => c.CustomerID)
                .ToList();
        }
    }
}
