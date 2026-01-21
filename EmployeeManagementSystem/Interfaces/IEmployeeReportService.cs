using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IEmployeeReportService
    {
        string GenerateReport(Employee employee);
    }
}
