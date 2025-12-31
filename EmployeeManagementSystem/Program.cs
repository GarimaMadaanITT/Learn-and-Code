using System;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Repositories;
using EmployeeManagementSystem.Services;

class Program
{
    static void Main()
    {
        IEmployeeRepository repository = new EmployeeRepository();
        IEmployeeService employeeService = new EmployeeService(repository);

        IEmployeeReportService xmlReportService = new XmlReportService();
        IEmployeeReportService csvReportService = new CsvReportService();

        var employee1 = new Employee(1, "Priyanka Jonas", "Engineering");

        repository.Save(employee1);

        Console.WriteLine("XML Report:");
        Console.WriteLine(xmlReportService.GenerateReport(employee1));

        Console.WriteLine("CSV Report:");
        Console.WriteLine(csvReportService.GenerateReport(employee1));

        Console.WriteLine("Is Working:");
        Console.WriteLine(employeeService.CheckIfWorking(employee1));

        employeeService.TerminateEmployee(employee1);

        Console.WriteLine("Is Working After Termination:");
        Console.WriteLine(employeeService.CheckIfWorking(employee1));
    }
}
