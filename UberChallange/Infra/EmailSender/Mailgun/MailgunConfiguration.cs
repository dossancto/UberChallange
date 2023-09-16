namespace UberChallange.Infra.EmailSender.Mailgun;

public class MailgunConfiguration : EmailsenderConfiguration
{
    public string ApiKey { get; }

    public MailgunConfiguration()
    {
        ApiKey = Environment.GetEnvironmentVariable("MAILGUN_API_KEY") ?? throw new InvalidOperationException("MailGun API KEY not founded");
    }
}
