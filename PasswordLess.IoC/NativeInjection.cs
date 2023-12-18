using PasswordLess.Application.Interfaces;
using PasswordLess.Application.Services;
using PasswordLess.Domain.Interfaces;
using PasswordLess.Domain.Transactions;
using PasswordLess.Infrastructure.Context;
using PasswordLess.Infrastructure.Repositories;
using PasswordLess.Infrastructure.Transactions;
using Microsoft.Extensions.DependencyInjection;
using PasswordLess.Infrastructure.Interfaces;
using PasswordLess.Infrastructure.Services;
using PasswordLess.Jwt.Interfaces;
using PasswordLess.Jwt.Services;

namespace PasswordLess.IoC;

public static class NativeInjector
{
    public static void RegisterServices(IServiceCollection services)
    {
        RegisterApplicationServices(services);
        RegisterInfrastructureServices(services);
        RegisterDomainServices(services);
    }

    private static void RegisterApplicationServices(IServiceCollection services)
    {
        // Application - Services
        services.AddScoped<IAuthService, AuthService>();
    }

    private static void RegisterInfrastructureServices(IServiceCollection services)
    {
        // Infra - Data
        services.AddScoped<PasswordLessDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Infra - Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtServices, JwtServices>();
        services.AddTransient<IEmailService, EmailService>();
    }

    private static void RegisterDomainServices(IServiceCollection services)
    { }
}