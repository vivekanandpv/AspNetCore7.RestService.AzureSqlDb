using Microsoft.EntityFrameworkCore;
using WebApplication7.Context;
using WebApplication7.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<EmployeeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSql"));
});
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

app.MapControllers();

app.Run();