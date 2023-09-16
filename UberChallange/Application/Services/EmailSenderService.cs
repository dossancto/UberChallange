using UberChallange.Adapters;
using UberChallange.Domain.Usecases;

namespace UberChallange.Application.Services;

public class EmailSenderService : IEmailSenderUsecase
{
    private IEmailSenderGateway _emailSender;

    public EmailSenderService(IEmailSenderGateway emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task SendEmail(string to, string subject, string body)
    {
        await _emailSender.SendEmail(to, subject, body);
    }
}
