using System.Collections.Generic;
using System.Text;
using CustomerManagement.Models;

namespace CustomerManagement.Utils
{
    public static class CsvExporter
    {
        public static string ExportToCsv(List<Customer> customers)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var c in customers)
            {
                sb.AppendFormat("{0},{1},{2},{3}", c.CustomerID, c.CompanyName, c.ContactName, c.Country);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
