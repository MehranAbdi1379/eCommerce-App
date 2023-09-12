using eCommerce.Service.User.Queries;
using Framework.Notification;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.User.Handlers;

public class SendPasswordResetEmailHandler : IRequestHandler<SendPasswordResetEmailCommand, Task>
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly EmailServices emailServices;
    public SendPasswordResetEmailHandler(UserManager<IdentityUser> userManager , IEmailService emailService)
    {
        this.userManager = userManager;
        emailServices = new EmailServices(emailService);
    }
    public async Task<Task> Handle(SendPasswordResetEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        var token = await userManager.GeneratePasswordResetTokenAsync(user);

        return emailServices.SendPasswordResetEmail(request.Email, token);
    }
}
