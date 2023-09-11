using eCommerce.Service.Contracts;
using eCommerce.Service.Contracts.DTO;
using eCommerce.Service.User.Commands;
using eCommerce.Service.User.Queries;
using Framework.Authentication.Service;
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

namespace eCommerce.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly EmailServices emailServices;
        private readonly IMediator mediator;

        public UserService(UserManager<IdentityUser> userManager , IConfiguration configuration , IEmailService emailService , IMediator mediator)
        {
            this.userManager = userManager;
            emailServices = new EmailServices(emailService);
            this.mediator = mediator;
        }

        public async Task<IdentityResult> SignUp(SignUpDTO dto)
        {
            return await mediator.Send(new SignUserUpCommand(dto));
        }
        public async Task<SignInInformationDTO> SignIn(SignUpDTO dto)
        {
            return await mediator.Send(new SignUserInQuery(dto));
        }
        public async Task<IdentityResult> VerifyEmail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);
            var result = await userManager.ConfirmEmailAsync(user, token);

            return result;
        }
        public async Task SendPasswordResetEmail(string email)
        {
            var user =  userManager.FindByEmailAsync(email).Result;

            var token = userManager.GeneratePasswordResetTokenAsync(user).Result;

            await emailServices.SendPasswordResetEmail(email, token);
        }
        public async Task<IdentityResult> ChangePassword(ResetPasswordDTO dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);
            var result = await userManager.ResetPasswordAsync(user, dto.Token, dto.newPassword);

            return result;
        }
    }
}
