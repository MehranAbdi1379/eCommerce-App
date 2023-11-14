using eCommerce.Domain.Models;
using eCommerce.Service.User.Commands;
using Framework.Notification;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.User.Handlers;

public class SignUserUpHandler : IRequestHandler<SignUserUpCommand, IdentityResult>
{
    private readonly UserManager<ApiUser> userManager;
    private readonly EmailServices emailServices;
    public SignUserUpHandler(UserManager<ApiUser> userManager , IEmailService emailService)
    {
        this.userManager = userManager;
        this.emailServices = new EmailServices(emailService);
    }
    public async Task<IdentityResult> Handle(SignUserUpCommand request, CancellationToken cancellationToken)
    {
        var user = new ApiUser()
        {
            Email = request.Dto.Email,
            UserName = request.Dto.Email,
            FirstName= request.Dto.FirstName, 
            LastName= request.Dto.LastName
        };
        var result = await userManager.CreateAsync(user, request.Dto.Password);

        await userManager.AddToRoleAsync(user, "customer");

        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

        if (result.Succeeded)
        {
            
            await emailServices.SendVerificationEmail(request.Dto.Email, user.Id, token);
        }

        return result;
    }
}
