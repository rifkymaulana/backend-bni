using api.Contracts;
using api.DataTransferObjects;
using api.Models;

namespace api.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public IEnumerable<EmployeeDto> GetAll()
    {
        var employees = _employeeRepository.GetAll().ToList();
        if (!employees.Any()) return Enumerable.Empty<EmployeeDto>();
        List<EmployeeDto> employeeDtos = new();

        foreach (var employee in employees)
        {
            employeeDtos.Add((EmployeeDto)employee);
        }
        return employeeDtos;
    }

    public EmployeeDto? GetById(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null) return null;
        return (EmployeeDto)employee;
    }

    public EmployeeDtoCreate? Create(EmployeeDtoCreate employeeDtoCreate)
    {
        var employee = (Employee)employeeDtoCreate;
        var createdEmployee = _employeeRepository.Create(employee);
        if (createdEmployee is null) return null;
        return (EmployeeDtoCreate)createdEmployee;
    }

    public int Update(EmployeeDto employeeDto)
    {
        var employee = _employeeRepository.GetByGuid(employeeDto.Guid);
        if (employee is null) return -1;

        var updatedEmployee = _employeeRepository.Update((Employee)employeeDto);
        return updatedEmployee ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null) return -1;

        var deletedEmployee = _employeeRepository.Delete(employee);
        return deletedEmployee ? 1 : 0;
    }
}
