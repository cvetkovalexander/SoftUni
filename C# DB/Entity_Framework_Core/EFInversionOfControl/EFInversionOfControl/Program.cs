using EFInversionOfControl.Data;
using EFInversionOfControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace EFInversionOfControl;

public class Program
{
    static async Task Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        IServiceProvider serviceProvider = new ServiceCollection()
            .AddDbContext<SoftUniDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
            .AddScoped<IRepository, Repository>()
            .BuildServiceProvider();

        using IServiceScope scope = serviceProvider
            .CreateScope();

        IRepository repository = scope
            .ServiceProvider
            .GetRequiredService<IRepository>();

        var employees = await repository
            .All<Employee>()
            .Where(e => e.Salary > 50000)
            .ToArrayAsync();

        foreach (var employee in employees)
            Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.Salary}");
    }
}
