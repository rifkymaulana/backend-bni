using api.Models;

namespace api.DataTransferObjects;

public class EmployeeDtoCreate
{
    public string Name { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public string PhotoPath { get; set; }

    // implicit operator
    public static implicit operator Employee(EmployeeDtoCreate employeeDtoCreate)
    {
        return new Employee
        {
            Guid = Guid.NewGuid(),
            Name = employeeDtoCreate.Name,
            Department = employeeDtoCreate.Department,
            Email = employeeDtoCreate.Email,
            PhotoPath = employeeDtoCreate.PhotoPath,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    // explicit operator
    public static explicit operator EmployeeDtoCreate(Employee employee)
    {
        return new EmployeeDtoCreate
        {
            Name = employee.Name,
            Department = employee.Department,
            Email = employee.Email,
            PhotoPath = employee.PhotoPath
        };
    }
}
