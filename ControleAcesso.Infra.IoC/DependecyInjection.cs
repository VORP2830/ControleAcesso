using ControleAcesso.Application.Interfaces;
using ControleAcesso.Application.Mappings;
using ControleAcesso.Application.Services;
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
        //AutoMapper
        service.AddAutoMapper(typeof(MappingProfile));
        //Repository
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        //Service
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<ITokenService, TokenService>();
        service.AddScoped<IUserProfileService, UserProfileService>();
        service.AddScoped<IProfileService, ProfileService>();
        service.AddScoped<IFunctionalityProfileService, FunctionalityProfileService>();
        service.AddScoped<IFunctionalityService, FunctionalityService>();
        service.AddScoped<IMethodService, MethodService>();
        service.AddScoped<IMenuOptionService, MenuOptionService>();

        return service;
    }
}