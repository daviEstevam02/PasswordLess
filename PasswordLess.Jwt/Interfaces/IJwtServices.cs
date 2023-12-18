using PasswordLess.Domain.Entities;

namespace PasswordLess.Jwt.Interfaces;

public interface IJwtServices
{
    string GenerateToken(User user);
}