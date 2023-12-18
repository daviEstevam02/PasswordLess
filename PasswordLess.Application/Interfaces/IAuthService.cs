using PasswordLess.Application.Core;
using PasswordLess.Application.ViewModels;

namespace PasswordLess.Application.Interfaces;

public interface IAuthService
{
    Task<ServiceResponse> AuthVerifyCode(VerifyCodeRequestViewModel viewModel);
    Task<ServiceResponse> AuthSendCodeEmail(AuthUserRequestViewModel viewModel);
}