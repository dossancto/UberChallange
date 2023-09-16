using Microsoft.AspNetCore.Mvc;

using UberChallange.Application.Services;
using UberChallange.Domain.Dtos;
using UberChallange.Domain.Exceptions.EmailSender;

[ApiController]
[Route("/api/SendEmail")]
public class EmailSenderController : ControllerBase
{
    private readonly EmailSenderService _emailSender;
    public EmailSenderController(EmailSenderService emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpPost("plain")]
    public async Task<IActionResult> AllFromUser(EmailRequest emailRequest)
    {
        try
        {
            await _emailSender.SendEmail(emailRequest.To, emailRequest.Subject, emailRequest.Body);
            return Ok("Deu tudo certo");
        }
        catch (EmailsenderException ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}
