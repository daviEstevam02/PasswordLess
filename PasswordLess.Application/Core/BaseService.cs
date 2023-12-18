using AutoMapper;
using Flunt.Notifications;
using PasswordLess.Domain.Core;
using PasswordLess.Domain.Transactions;
using PasswordLess.Jwt.Interfaces;

namespace PasswordLess.Application.Core;

public abstract class BaseService<T, TRepository>: Notifiable<Notification>,
    IBaseService<T, TRepository>
    where T: Entity
    where TRepository: IBaseRepository<T>
{
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly TRepository _repository;

    protected BaseService( IMapper mapper, IUnitOfWork unitOfWork, TRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
}