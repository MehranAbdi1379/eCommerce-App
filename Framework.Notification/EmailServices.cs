using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Notification
{
    public class EmailServices
    {
        private IEmailService emailService;

        public EmailServices(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        public async Task SendVerificationEmail(string email ,string userId, string token)
        {
            await emailService.SendAsync(email, "eCommerce Verification Link", $"<a href=\"http://localhost:5173/email-verified?userId={userId}&token={token}\">Verify Email<a/>", true);
        }
        public async Task SendPasswordResetEmail(string email , string token)
        {
            await emailService.SendAsync(email, "eCommerce Password Reset Link", $"<a href=\"http://localhost:5173/password-reset?email={email}&token={token}\">Reset Password<a/>" , true);
        }
    }
}
