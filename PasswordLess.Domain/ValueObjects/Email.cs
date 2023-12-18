using Flunt.Validations;
using PasswordLess.Domain.Core;

namespace PasswordLess.Domain.ValueObjects;

public sealed class Email: ValueObject
{

    private Email()
    {
        
    }

    public Email(string emailAddress)
    {
        EmailAddress = emailAddress;
        Validate();
    }

    public string EmailAddress { get; private set; } = string.Empty;

    protected override void Validate()
        => AddNotifications(new Contract<Email>()
            .Requires()
            .IsEmail(EmailAddress, "Email.EmailAddress", "Email address is invalid")
        );
    
    public override string ToString()
        => EmailAddress;

}