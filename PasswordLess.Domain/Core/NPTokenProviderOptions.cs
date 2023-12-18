using Microsoft.AspNetCore.Identity;

namespace PasswordLess.Domain.Core;

public class NPTokenProviderOptions : DataProtectionTokenProviderOptions
{
    public NPTokenProviderOptions()
    {
        Name = "NPTokenProvider";
        TokenLifespan = TimeSpan.FromMinutes(5);
    }
}