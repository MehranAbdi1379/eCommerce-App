using eCommerce.Service.Contracts;
using eCommerce.Service.Contracts.DTO;
using Framework.Authentication.Service;
using Framework.Notification;
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
        private readonly AuthManager authManager;
        private readonly EmailServices emailServices;

        public UserService(UserManager<IdentityUser> userManager , IConfiguration configuration , IEmailService emailService)
        {
            this.userManager = userManager;
            authManager = new AuthManager(userManager , configuration);
            emailServices = new EmailServices(emailService);
        }

        public async Task<IdentityResult> SignUp(SignUpDTO dto)
        {
            var user = new IdentityUser()
            {
                Email = dto.Email,
                UserName = dto.Email
            };
            var result = await userManager.CreateAsync(user, dto.Password);

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

            if(result.Succeeded)
            {
                await emailServices.SendVerificationEmail(dto.Email , user.Id , token);
            }

            return result;
        }
        public async Task<SignInInformationDTO> SignIn(SignUpDTO dto)
        {
            if (await authManager.ValidateUser(new UserSignInDTO { Email = dto.Email, Password = dto.Password }))
            {
                return new SignInInformationDTO
                {
                    Token = await authManager.CreateToken(),
                    UserId = userManager.FindByEmailAsync(dto.Email).Result.Id
                };
            }
            return null;
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
