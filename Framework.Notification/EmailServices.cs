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
        private IEmailService emailServvice;

        public EmailServices(IEmailService emailService)
        {
            this.emailServvice = emailService;
        }
        public async Task SendVerificationEmail(string email ,string userId, string token)
        {
            await emailServvice.SendAsync(email, "eCommerce Verification Link", $"<a href=\"https://localhost:7209/api/user/verify-email?userId={userId}&token={token}\">Verify Email<a/>", true);
        }
    }
}
