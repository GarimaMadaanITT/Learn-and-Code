namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Department { get; set; }
        public bool IsWorking { get; set; } = true;

        public Employee(int id, string name, string department)
        {
            Id = id;
            Name = name;
            Department = department;
        }
    }
}
