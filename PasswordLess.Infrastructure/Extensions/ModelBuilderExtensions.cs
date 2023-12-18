using Microsoft.EntityFrameworkCore;
using PasswordLess.Infrastructure.Mappings;

namespace PasswordLess.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    public static void ConfigureMappings(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}