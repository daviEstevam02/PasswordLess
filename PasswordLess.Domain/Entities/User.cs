using PasswordLess.Domain.Core;

namespace PasswordLess.Domain.Entities;
using PasswordLess.Domain.ValueObjects;

public sealed class User : Entity
{
    private User()
    {}
    
    public User(
        Guid id,
        Email email,
        Username? username = null
      )
    {
        Id = id;
        Email = email;
        Username = username ?? new Username(Email.EmailAddress.Split("@")[0]);
        PasswordCode = PasswordCode.GenerateNewPasscode();
        Validate();
    }
    
    public Guid Id { get; set; }
    public Email Email { get; private set; } = default!;
    public Username Username { get; private set; } = default!;
    public PasswordCode PasswordCode { get; private set; } = default!;

    public void UpdatePasswordCode() =>
        PasswordCode = PasswordCode.GenerateNewPasscode();

    protected override void Validate()
    {
        AddNotifications(Email);
        AddNotifications(Username);
        AddNotifications(PasswordCode);
    }
    
}