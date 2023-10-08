using api.DataTransferObjects;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var employees = _employeeService.GetAll();
        if (!employees.Any()) return NotFound();
        return Ok(employees);
    }

    [HttpGet("{guid}")]
    public IActionResult GetById(Guid guid)
    {
        var employee = _employeeService.GetById(guid);
        if (employee is null) return NotFound();
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Create(EmployeeDtoCreate employeeDtoCreate)
    {
        var createdEmployee = _employeeService.Create(employeeDtoCreate);
        if (createdEmployee is null) return BadRequest();
        return Ok(createdEmployee);
    }

    [HttpPut]
    public IActionResult Update(EmployeeDto employeeDto)
    {
        var updatedEmployee = _employeeService.Update(employeeDto);
        if (updatedEmployee == -1) return NotFound();
        var employee = _employeeService.GetById(employeeDto.Guid);
        return Ok(employee);
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var deletedEmployee = _employeeService.Delete(guid);
        if (deletedEmployee == -1) return NotFound();
        return Ok("Employee deleted successfully");
    }
}
