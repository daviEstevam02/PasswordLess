using Microsoft.EntityFrameworkCore;
using PasswordLess.Infrastructure.Context;

namespace PasswordLess.Api.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        string PasswordLessConnection = configuration.GetConnectionString("PasswordLessConnection")!;

        services.AddDbContext<PasswordLessDbContext>(options =>
        {
            options.UseMySql(PasswordLessConnection, ServerVersion.AutoDetect(PasswordLessConnection),
                    options => options.EnableRetryOnFailure())
                .EnableSensitiveDataLogging();
        });
    }
}