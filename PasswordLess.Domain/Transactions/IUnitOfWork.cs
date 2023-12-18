namespace PasswordLess.Domain.Transactions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}