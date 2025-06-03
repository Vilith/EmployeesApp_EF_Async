using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Employees.Services;

public class OtherEmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public void Add(Employee employee)
    {
        employeeRepository.AddAsync(employee);
    }

    public Employee[] GetAll()
    {
        return employeeRepository.GetAllAsync();
    }

    public Employee? GetById(int id) => employeeRepository.GetByIdAsync(id);

    public bool CheckIsVIP(Employee employee) =>
        employee.Email.StartsWith("ADMIN", StringComparison.CurrentCultureIgnoreCase);
}