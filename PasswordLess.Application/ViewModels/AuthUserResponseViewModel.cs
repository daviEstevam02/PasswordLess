namespace PasswordLess.Application.ViewModels;

public sealed record AuthUserResponseViewModel(string Email, string Username)
{
    public string Token { get; set; } = string.Empty;
}