using AutoMapper;
using PasswordLess.Domain.ValueObjects;

namespace PasswordLess.Application.AutoMapper;

public sealed class GeneralMappingProfile: Profile
{
    public GeneralMappingProfile()
    {
        CreateMap<Email, string>()
            .ConstructUsing(email => email.EmailAddress);
        CreateMap<Username, string>()
            .ConstructUsing(username => username.UsernameTyped);
        CreateMap<PasswordCode, string>()
            .ConstructUsing(password => password.Code.ToString());
        
        CreateMap<string, Email>()
            .ConstructUsing(text => new Email(text));
        CreateMap<string, Username>()
            .ConstructUsing(text => new Username(text));
    }
}