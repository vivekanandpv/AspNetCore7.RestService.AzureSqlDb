using Microsoft.EntityFrameworkCore;
using WebApplication7.Context;
using WebApplication7.Models;

namespace WebApplication7.Services;

public class EmployeeService : IEmployeeService
{
    private readonly EmployeeContext _context;

    public EmployeeService(EmployeeContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<Employee> CreateAsync(Employee employee)
    {
        await _context.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UpdateAsync(int id, Employee employee)
    {
        var employeeDb = await GetByIdAsync(id);
        
        employeeDb.FirstName = employee.FirstName;
        employeeDb.LastName = employee.LastName;
        employeeDb.Email = employee.Email;

        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var employee = await GetByIdAsync(id);
        _context.Employees.Remove(employee);

        await _context.SaveChangesAsync();
    }
}