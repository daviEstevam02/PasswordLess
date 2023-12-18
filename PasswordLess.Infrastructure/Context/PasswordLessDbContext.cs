using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using PasswordLess.Domain.Entities;
using PasswordLess.Infrastructure.Extensions;

namespace PasswordLess.Infrastructure.Context;

public sealed class PasswordLessDbContext : DbContext
{
    public PasswordLessDbContext(DbContextOptions<PasswordLessDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<List<Notification>>();
    
        modelBuilder.ConfigureMappings();
        base.OnModelCreating(modelBuilder);
    }
}