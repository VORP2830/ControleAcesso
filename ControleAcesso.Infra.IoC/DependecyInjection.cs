using ControleAcesso.Domain.Interfaces;
using ControleAcesso.Infra.Data;
using ControleAcesso.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleAcesso.Infra.IoC;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE") ?? configuration.GetConnectionString("ConnectionString");
        service.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        service.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return service;
    }
}