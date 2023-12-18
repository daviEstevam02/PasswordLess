using PasswordLess.Domain.Core;

namespace PasswordLess.Application.Core;

public interface IBaseService<T, TRepository>
    where T : Entity
    where TRepository : IBaseRepository<T>
{
    
}

