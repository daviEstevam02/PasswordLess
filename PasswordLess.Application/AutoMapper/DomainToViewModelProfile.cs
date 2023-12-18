using AutoMapper;
using PasswordLess.Application.ViewModels;
using PasswordLess.Domain.Entities;

namespace PasswordLess.Application.AutoMapper;

public class DomainToViewModelProfile: Profile
{
    public DomainToViewModelProfile()
    {
        CreateMap<User, AuthUserResponseViewModel>();
    }
}