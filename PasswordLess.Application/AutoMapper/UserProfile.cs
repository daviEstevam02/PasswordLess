using AutoMapper;
using PasswordLess.Application.ViewModels;
using PasswordLess.Domain.Entities;

namespace PasswordLess.Application.AutoMapper;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<VerifyCodeRequestViewModel, User>();
        CreateMap<User, AuthUserResponseViewModel>();
        CreateMap<AuthUserRequestViewModel, User>();
    }
}