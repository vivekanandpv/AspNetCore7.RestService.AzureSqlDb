using WebApplication7.Models;

namespace WebApplication7.Services;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee> GetByIdAsync(int id);
    Task<Employee> CreateAsync(Employee employee);
    Task<Employee> UpdateAsync(int id, Employee employee);
    Task DeleteByIdAsync(int id);
}