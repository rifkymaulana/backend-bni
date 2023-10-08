using api.Models;

namespace api.DataTransferObjects;

public class EmployeeDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public string PhotoPath { get; set; }

    // implicit operator
    public static implicit operator EmployeeDto(Employee employee)
    {
        return new EmployeeDto
        {
            Guid = employee.Guid,
            Name = employee.Name,
            Department = employee.Department,
            Email = employee.Email,
            PhotoPath = employee.PhotoPath
        };
    }

    // explicit operator
    public static explicit operator Employee(EmployeeDto employeeDto)
    {
        return new Employee
        {
            Guid = employeeDto.Guid,
            Name = employeeDto.Name,
            Department = employeeDto.Department,
            Email = employeeDto.Email,
            PhotoPath = employeeDto.PhotoPath,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public static explicit operator EmployeeDto(bool v)
    {
        throw new NotImplementedException();
    }
}
