using AutoMapper;
using Flunt.Notifications;
using PasswordLess.Application.Core;
using PasswordLess.Application.Interfaces;
using PasswordLess.Application.ViewModels;
using PasswordLess.Domain.Entities;
using PasswordLess.Domain.Helper;
using PasswordLess.Domain.Interfaces;
using PasswordLess.Domain.Transactions;
using PasswordLess.Domain.ValueObjects;
using PasswordLess.Infrastructure.Interfaces;
using PasswordLess.Infrastructure.Models;
using PasswordLess.Jwt.Interfaces;

namespace PasswordLess.Application.Services;

public sealed class AuthService : BaseService<User, IUserRepository>, IAuthService
{
    private readonly IEmailService _emailService;
    private readonly IJwtServices _jwtServices;

    public AuthService(
        IEmailService emailService,
        IJwtServices jwtServices,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IUserRepository repository)
        : base(mapper, unitOfWork, repository)
    {
        _emailService = emailService;
        _jwtServices = jwtServices;
    }

    public async Task<ServiceResponse> AuthVerifyCode(VerifyCodeRequestViewModel viewModel)
    {
        var userExists = await _repository
            .GetOneAsync(user => user.Email.EmailAddress == viewModel.Email);
        
        if (userExists is null)
        {
            AddNotification("User", $"Usuário não encontrado!");
            return new ServiceResponse(false, Notifications.ToList());
        }

        var validateCode = await _repository
            .GetOneAsync(code => 
                code.Email.EmailAddress == viewModel.Email &&
                code.PasswordCode.Code == viewModel.PasswordCode.ToInt32() &&
                code.PasswordCode.ExpirationDate.Minute <= DateTime.UtcNow.Minute);

        if (validateCode is null)
        {
            AddNotification("User", $"Código de usuário inválido");
            return new ServiceResponse(false, Notifications.ToList());
        }
            
        var token = _jwtServices.GenerateToken(userExists);
        var response = _mapper.Map<AuthUserResponseViewModel>(userExists) with
        {
            Token = token
        };

        return new ServiceResponse(true, response);
    }

    public async Task<ServiceResponse> AuthSendCodeEmail(AuthUserRequestViewModel viewModel)
    {
        //Verificar usuario existente
        var userExists = await _repository.GetOneAsync(user => user.Email.EmailAddress == viewModel.Email);

        //Se não existe criar
        if (userExists is null)
        {
            var user = new User(
                Guid.NewGuid(),
                new Email(viewModel.Email)
            );

            if (!user.IsValid)
                return new ServiceResponse(false, user.Notifications);
            try
            {
                await _repository.AddAsync(user);

                var emailModel = new EmailModel(
                    viewModel.Email,
                    EmailModel.CLUB_USER_CREATED_SUBJECT,
                    EmailModel.CLUB_USER_CREATED_BODY(user.PasswordCode.Code.ToString()!)
                );

                await _emailService.SendEmail(emailModel);

                if (await _unitOfWork.SaveChangesAsync() <= 0)
                {
                    AddNotification("User", "Não foi possível criar o usuário.");
                    return new ServiceResponse(false, Notifications.ToList());
                }
            }
            catch (Exception)
            {
                AddNotification("User", "Erro ao criar e enviar e-mail ao usuário");
                return new ServiceResponse(false, Notifications.ToList());
            }

            return new ServiceResponse(true, "Código enviado por email com sucesso");
        }

        // Verificar se ele tem passwordcode valido
        if (userExists.PasswordCode.IsValid)
        {
            var emailModel = new EmailModel(
                viewModel.Email,
                EmailModel.CLUB_USER_CREATED_SUBJECT,
                EmailModel.CLUB_USER_CREATED_BODY(userExists.PasswordCode.Code.ToString()!)
            );

            await _emailService.SendEmail(emailModel);
            
            return new ServiceResponse(true, "Código enviado por email com sucesso lalal");
        }
        
        //Se passwordcode não é valido, gerar um novo
        try
        {
            userExists.UpdatePasswordCode();
            
             _repository.Update(userExists);

            var sendEmail = new EmailModel(
                viewModel.Email,
                EmailModel.CLUB_USER_CREATED_SUBJECT,
                EmailModel.CLUB_USER_CREATED_BODY(userExists.PasswordCode.Code.ToString()!)
            );
            
            await _emailService.SendEmail(sendEmail);
            
            
            if (await _unitOfWork.SaveChangesAsync() <= 0)
            {
                AddNotification("User", "Não foi possível criar o usuário.");
                return new ServiceResponse(false, Notifications.ToList());
            }
        }
        catch (Exception)
        {
            AddNotification("User", "Erro ao criar e enviar e-mail ao usuário");
            return new ServiceResponse(false, Notifications.ToList());
        }
       
        return new ServiceResponse(true, "Código enviado por email com sucesso");
    }
}