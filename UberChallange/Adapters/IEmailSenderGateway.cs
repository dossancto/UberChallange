namespace UberChallange.Adapters;

public interface IEmailSenderGateway
{
    Task SendEmail(string to, string subject, string body);
}
