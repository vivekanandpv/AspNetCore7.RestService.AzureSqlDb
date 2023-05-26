using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Context;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
}