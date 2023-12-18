using AutoMapper;
using PasswordLess.Application.ViewModels;
using PasswordLess.Domain.Entities;

namespace PasswordLess.Application.AutoMapper;

public sealed class ViewModelToDomainProfile : Profile
{
    public ViewModelToDomainProfile()
    {
        CreateMap<VerifyCodeRequestViewModel, User>();
        CreateMap<AuthUserRequestViewModel, User>();
    }
}