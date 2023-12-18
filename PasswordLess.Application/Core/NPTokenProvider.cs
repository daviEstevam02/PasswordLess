namespace PasswordLess.Application.Core;

public class NPTokenProvider<TUser> : DataProtectorTokenProvider<TUser>
    where TUser : IdentityUser
{
    public NPTokenProvider(
        IDataProtectionProvider dataProtectionProvider,
        IOptions<NPTokenProviderOptions> options, ILogger<NPTokenProvider<TUser>> logger)
        : base(dataProtectionProvider, options, logger)
    { }
}

public static class CustomIdentityBuilderExtensions
{
    public static IdentityBuilder AddNPTokenProvider(this IdentityBuilder builder)
    {
        var userType = builder.UserType;
        var provider = typeof(NPTokenProvider<>).MakeGenericType(userType);
        return builder.AddTokenProvider("NPTokenProvider", provider);
    }
}