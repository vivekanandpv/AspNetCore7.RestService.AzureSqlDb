using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using WebApplication7.Services;

namespace WebApplication7.Controllers;

[Route("api/v1/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeesController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllAsync()
    {
        return Ok(await _service.GetAllAsync());
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Employee>> GetByIdAsync(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> CreateAsync(Employee employee)
    {
        return Ok(await _service.CreateAsync(employee));
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Employee>> UpdateAsync(int id, Employee employee)
    {
        return Ok(await _service.UpdateAsync(id, employee));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteByIdAsync(int id)
    {
        await _service.DeleteByIdAsync(id);
        return Ok();
    }
}