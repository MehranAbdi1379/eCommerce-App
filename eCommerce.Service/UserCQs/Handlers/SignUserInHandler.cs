﻿using eCommerce.Service.Contracts.DTO;
using eCommerce.Service.User.Queries;
using Framework.Authentication.Service;
using MediatR; 
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.User.Handlers
{
    public class SignUserInHandler : IRequestHandler<SignUserInQuery, SignInInformationDTO>
    {
        private readonly AuthManager authManager;
        private readonly UserManager<IdentityUser> userManager;
        public SignUserInHandler(IConfiguration configuration , UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            authManager = new AuthManager(userManager , configuration);
        }
        public async Task<SignInInformationDTO> Handle(SignUserInQuery request, CancellationToken cancellationToken)
        {
            if (await authManager.ValidateUser(new UserSignInDTO { Email = request.Dto.Email, Password = request.Dto.Password }))
            {
                return new SignInInformationDTO
                {
                    Token = await authManager.CreateToken(),
                    UserId = userManager.FindByEmailAsync(request.Dto.Email).Result.Id
                };
            }
            else
                return new SignInInformationDTO();
        }
    }
}
