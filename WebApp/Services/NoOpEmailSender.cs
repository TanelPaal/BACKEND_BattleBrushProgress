using Microsoft.AspNetCore.Identity.UI.Services;

namespace WebApp.Services;

public class NoOpEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Log the email instead of actually sending it
        Console.WriteLine($"Email would have been sent to: {email}");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Message: {htmlMessage}");
        
        return Task.CompletedTask;
    }
} 