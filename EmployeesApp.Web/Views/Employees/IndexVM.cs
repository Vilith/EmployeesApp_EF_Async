using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Web.Views.Employees
{
    public class IndexVM
    {
        public EmployeeVM[] EmployeeVMs { get; set; } = null!;

        public class EmployeeVM
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required bool ShowAsHighlighted { get; set; }
            public Company? Company { get; set; } = null!; // Navigation property for Company
        }
    }
}
