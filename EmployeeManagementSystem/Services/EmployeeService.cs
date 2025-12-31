using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using System;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void TerminateEmployee(Employee employee)
        {
            employee.IsWorking = false;
            _employeeRepository.Update(employee);
            Console.WriteLine($"[Service] Employee {employee.Name} has been terminated.");
        }

        public bool CheckIfWorking(Employee employee)
        {
            return employee.IsWorking;
        }
    }
}
