using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using PasswordLess.Domain.Helper;
using PasswordLess.Infrastructure.Interfaces;
using PasswordLess.Infrastructure.Models;

namespace PasswordLess.Infrastructure.Services;

public sealed class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmail(EmailModel emailModel)
    {
        MailMessage email = new();

        foreach (var reciever in emailModel.Recievers.Split(';'))
        {
            if (reciever.IsEmpty()) continue;
            email.To.Add(reciever);
        }

        email.From = new MailAddress(_configuration["SmtpClient:EmailAddress"]!.ToString());
        email.Subject = emailModel.Subject;
        email.IsBodyHtml = true;
        email.Body = emailModel.Body;

        SmtpClient _client = new(_configuration["SmtpClient:Smtp"]!.ToString());
        try
        {
            using (_client)
            {
                _client.Port = Convert.ToInt32(_configuration["SmtpClient:Port"]!.ToString());
                _client.DeliveryMethod = SmtpDeliveryMethod.Network;
                _client.UseDefaultCredentials = false;
                _client.Credentials = new NetworkCredential(
                    _configuration["SmtpClient:EmailAddress"]!.ToString(),
                    _configuration["SmtpClient:EmailPassword"]!.ToString()
                );
                _client.EnableSsl = true;
                await _client.SendMailAsync(email);
            }
            _client.Dispose();
        }
        catch (Exception)
        {
            throw;
        }
    }
}