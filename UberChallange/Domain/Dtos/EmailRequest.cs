namespace UberChallange.Domain.Dtos;

public record EmailRequest(string To, string Subject, string Body) { }
