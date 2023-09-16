namespace UberChallange.Domain.Usecases;

public interface IEmailSenderUsecase
{
    Task SendEmail(string to, string subject, string body);
}
