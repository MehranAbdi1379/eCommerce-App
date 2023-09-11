﻿using eCommerce.Service.Contracts;
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
        private readonly IMediator mediator;

        public UserService(IMediator mediator)
        {
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
            return await mediator.Send(new VerifyUserEmailCommand(userId, token));
        }
        public async Task<Task> SendPasswordResetEmail(string email)
        {
            return await mediator.Send(new SendPasswordResetEmailCommand(email));
        }
        public async Task<IdentityResult> ChangePassword(ResetPasswordDTO dto)
        {
            return await mediator.Send(new UpdatePasswordCommand(dto));
        }
    }
}
