using BuildingCore.Data.Identity;
using Microsoft.AspNetCore.Identity;

namespace BuildingCore.Extentions
{
    public class SmtpEmailSender : IEmailSender<ApplicationUser>
    {
        public Task SendEmailAsync(ApplicationUser user, string email, string subject, string htmlMessage)
        {
            // Implement SMTP sending here
            return Task.CompletedTask;
        }

        public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) =>
            SendEmailAsync(user, email, "Confirm your account", confirmationLink);

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink) =>
            SendEmailAsync(user, email, "Reset your password", resetLink);

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
        {
            throw new NotImplementedException();
        }
    }

}
