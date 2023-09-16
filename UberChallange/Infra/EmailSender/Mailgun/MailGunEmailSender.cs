using System.Net.Http.Headers;
using System.Text;
using UberChallange.Adapters;
using UberChallange.Domain.Exceptions.EmailSender;

namespace UberChallange.Infra.EmailSender.Mailgun;

public class MailGunEmailSender : IEmailSenderGateway
{
    private readonly MailgunConfiguration _emailconfiguration;

    public MailGunEmailSender(MailgunConfiguration mailgunConfiguration)
    {
        _emailconfiguration = mailgunConfiguration;
    }

    public async Task SendEmail(string to, string subject, string body)
    {
        using (var httpClient = new HttpClient())
        {
            var authToken = Encoding.ASCII.GetBytes($"api:{_emailconfiguration.ApiKey}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

            var formContent = new FormUrlEncodedContent(new Dictionary<string, string> {
        { "from", $"Mailgun Sandbox <postmaster@{_emailconfiguration.Domain}>"},
        { "h:Reply-To", $"{_emailconfiguration.DisplayName} <{_emailconfiguration.ReplyTo}>" },
        { "to", to },
        { "subject", subject },
        { "text", body }
    });

            var result = await httpClient.PostAsync($"https://api.mailgun.net/v3/{_emailconfiguration.Domain}/messages", formContent);

            if (!result.IsSuccessStatusCode)
            {
                string responseBody = await result.Content.ReadAsStringAsync();
                throw new EmailsenderException(responseBody);
            }
        }
    }
}
