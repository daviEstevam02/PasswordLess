using Flunt.Validations;
using PasswordLess.Domain.Core;
using PasswordLess.Domain.Helper;

namespace PasswordLess.Domain.ValueObjects;

public sealed class Username : ValueObject
{
    private Username(){}
    
    public Username(string usernameTyped)
    {
        UsernameTyped = usernameTyped;
        Validate();
    }

    public string UsernameTyped { get; private set; } = string.Empty;
    
    protected override void Validate()
        => AddNotifications(new Contract<Username>()
            .Requires()
            .IsTrue(UsernameTyped.IsNotEmpty(), "Username.UsernameTyped", "Username cannot be empty.")
        );
}