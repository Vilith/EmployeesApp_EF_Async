using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Employees.Interfaces
{
    public interface IEmployeeRepository
    {
        void AddAsync(Employee employee);
        Employee[] GetAllAsync();
        Employee? GetByIdAsync(int id);
    }
}