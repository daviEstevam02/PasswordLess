using System.Text;
using Flunt.Validations;
using PasswordLess.Domain.Core;
using PasswordLess.Domain.Helper;

namespace PasswordLess.Domain.ValueObjects;

public sealed class PasswordCode: ValueObject
{
    private PasswordCode(DateTime expirationDate)
    {
        Code = GenerateCode().ToInt32();
        ExpirationDate = expirationDate;
        Validate();
    }

    public int Code { get; private set; }
    public DateTime ExpirationDate { get; private set; }

    public static PasswordCode GenerateNewPasscode() => 
         new PasswordCode
        (
           expirationDate: DateTime.UtcNow.AddMinutes(5)
        );
    protected override void Validate()
        => AddNotifications(new Contract<PasswordCode>()
            .Requires()
            .IsLowerOrEqualsThan(ExpirationDate, DateTime.UtcNow, "PasswordCode.ExpirationDate", "Expiration date must be in future")
        );
    
    private static string GenerateCode()
    {
        const string NUMBERS = "0123456789";
        var random = new Random();
        var length = 4;
        var chars = NUMBERS.ToCharArray().ToList();

        var result = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            result.Append(chars[random.Next(chars.Count)]);
        }

        return result.ToString();
    }
}
