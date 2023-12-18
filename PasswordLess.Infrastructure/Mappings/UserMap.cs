using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordLess.Domain.Entities;

namespace PasswordLess.Infrastructure.Mappings;

public sealed class UserMap: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(x => x.Id);

        //OwnsOne => Mapear tipo complexo para tipo primitivo
        builder.OwnsOne(user => user.Email, email =>
        {
            email.Property(e => e.EmailAddress)
                .HasColumnName("Email")
                .HasColumnType("varchar(150)");

            email
                .HasIndex(x => x.EmailAddress)
                .IsUnique();
            
            email.Ignore(e => e.Notifications);
        });

        builder.OwnsOne(user => user.Username, username =>
        {
            username.Property(u => u.UsernameTyped)
                .HasColumnType("varchar(30)")
                .HasColumnName("Username");

            username.Ignore(u => u.Notifications);
        });

        builder.OwnsOne(user => user.PasswordCode, password =>
        {
            password.Property(p => p.Code)
                .HasColumnType("varchar(16)")
                .HasColumnName("Code");
            
            password.Property(p => p.ExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("ExpirationDate");

            password.Ignore(p => p.Notifications);
        });

        builder.Ignore(x => x.Notifications);
    }
}