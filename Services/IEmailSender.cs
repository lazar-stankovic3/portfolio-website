namespace Portfolio.Services;

public interface IEmailSender
{
    Task SendContactMessageAsync(string name, string email, string message, CancellationToken cancellationToken = default);
}
