using Microsoft.AspNetCore.Mvc;
using PasswordLess.Api.Core;
using PasswordLess.Application.Interfaces;
using PasswordLess.Application.ViewModels;

namespace PasswordLess.Api.Controllers;

[Microsoft.AspNetCore.Components.Route("api/v1")]
public sealed class AuthenticationController: ApiController
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("/login")]
    public async Task<IActionResult> AuthSendCodeEmail([FromBody] AuthUserRequestViewModel viewModel)
        => CustomResponse(await _authService.AuthSendCodeEmail(viewModel));

    [HttpPost("/verify-code")]
    public async Task<IActionResult> CreateUserAsync([FromBody] VerifyCodeRequestViewModel viewModel)
        => CustomResponse(await _authService.AuthVerifyCode(viewModel));
}