using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PasswordLess.Domain.Core;
using PasswordLess.Domain.Entities;

public class NPTokenProvider<TUser> : DataProtectorTokenProvider<TUser>
    where TUser : User
{
    public NPTokenProvider(
        IDataProtectionProvider dataProtectionProvider,
        IOptions<NPTokenProviderOptions> options, 
        ILogger<NPTokenProvider<TUser>> logger
        ): base(dataProtectionProvider, options)
    { }
}