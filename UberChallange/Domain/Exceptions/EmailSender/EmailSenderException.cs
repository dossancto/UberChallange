namespace UberChallange.Domain.Exceptions.EmailSender;

public class EmailsenderException : Exception
{
    public EmailsenderException(string msg) : base(msg) { }
}
