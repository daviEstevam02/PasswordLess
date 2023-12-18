using PasswordLess.Domain.Entities;
using PasswordLess.Domain.Interfaces;
using PasswordLess.Infrastructure.Context;
using PasswordLess.Infrastructure.Core;

namespace PasswordLess.Infrastructure.Repositories;

public sealed class UserRepository: BaseRepository<User>, IUserRepository
{
    public UserRepository(PasswordLessDbContext context): base(context)
    {}
}