using System;
using System.Collections.Generic;
using CustomerManagement.Models;
using CustomerManagement.Services;
using CustomerManagement.Utils;

class Program
{
    static void Main(string[] args)
    {
        var searchService = new CustomerSearchService();

        Console.WriteLine("Search By Country: India");
        var byCountry = searchService.SearchByCountry("India");
        PrintResults(byCountry);

        Console.WriteLine("\nSearch By Company Name: 'Tec'");
        var byCompany = searchService.SearchByCompanyName("Tec");
        PrintResults(byCompany);

        Console.WriteLine("\nSearch By Contact: 'Sa'");
        var byContact = searchService.SearchByContact("Sa");
        PrintResults(byContact);

        Console.WriteLine("\nCSV Export (Country Search):");
        Console.WriteLine(CsvExporter.ExportToCsv(byCountry));

        Console.WriteLine("\nCSV Export (Company Search):");
        Console.WriteLine(CsvExporter.ExportToCsv(byCompany));

        Console.WriteLine("\nCSV Export (Contact Search):");
        Console.WriteLine(CsvExporter.ExportToCsv(byContact));
    }

    static void PrintResults(List<Customer> customers)
    {
        foreach (var c in customers)
        {
            Console.WriteLine($"{c.CustomerID} | {c.CompanyName} | {c.ContactName} | {c.Country}");
        }
    }
}
