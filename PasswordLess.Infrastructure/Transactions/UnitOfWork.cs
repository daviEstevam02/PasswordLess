using PasswordLess.Domain.Transactions;
using PasswordLess.Infrastructure.Context;

namespace PasswordLess.Infrastructure.Transactions;

public sealed class UnitOfWork: IUnitOfWork
{
    private readonly PasswordLessDbContext _context;

    public UnitOfWork(PasswordLessDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
}