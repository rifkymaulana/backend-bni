using System.ServiceModel;
using api.DataTransferObjects;
using api.Services;

namespace api.BusinessLogic;

[ServiceContract]
public interface ISoapService
{
    [OperationContract]
    IEnumerable<EmployeeDto> GetAllEmployees();

    [OperationContract]
    EmployeeDto GetEmployeeById(string guid);

    [OperationContract]
    EmployeeDtoCreate AddEmployee(string name, string department, string email, string photoPath);

    [OperationContract]
    EmployeeDto UpdateEmployee(string guid, string name, string department, string email, string photoPath);

    [OperationContract]
    int DeleteEmployee(string guid);
}

public class SoapService : ISoapService
{
    private readonly EmployeeService _employeeService;

    public SoapService(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public IEnumerable<EmployeeDto> GetAllEmployees()
    {
        return _employeeService.GetAll();
    }

    public EmployeeDto GetEmployeeById(string guid)
    {
        var id = Guid.Parse(guid ?? string.Empty); ;
        return _employeeService.GetById(id);
    }

    public EmployeeDtoCreate AddEmployee(string name, string department, string email, string photoPath)
    {
        var employeeDtoCreate = new EmployeeDtoCreate
        {
            Name = name,
            Department = department,
            Email = email,
            PhotoPath = photoPath
        };
        return _employeeService.Create(employeeDtoCreate);
    }

    public EmployeeDto UpdateEmployee(string guid, string name, string department, string email, string photoPath)
    {
        var id = Guid.Parse(guid ?? string.Empty);
        var employeeDto = new EmployeeDto
        {
            Guid = id,
            Name = name,
            Department = department,
            Email = email,
            PhotoPath = photoPath
        };
        var updated = _employeeService.Update(employeeDto);
        if (updated == 1)
        {
            var employee = _employeeService.GetById(id);
            return employee;
        }
        else
        {
            return null;
        }
    }

    public int DeleteEmployee(string guid)
    {
        var id = Guid.Parse(guid ?? string.Empty);
        return _employeeService.Delete(id);
    }
}
