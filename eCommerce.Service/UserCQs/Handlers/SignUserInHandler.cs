using eCommerce.Domain.Models;
using eCommerce.Service.Contracts.DTO;
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
        private readonly AuthManager<ApiUser> authManager;
        private readonly UserManager<ApiUser> userManager;
        public SignUserInHandler(IConfiguration configuration , UserManager<ApiUser> userManager)
        {
            this.userManager = userManager;
            authManager = new AuthManager<ApiUser>(userManager , configuration);
        }
        public async Task<SignInInformationDTO> Handle(SignUserInQuery request, CancellationToken cancellationToken)
        {
            if (await authManager.ValidateUser(new UserSignInDTO { Email = request.Dto.Email, Password = request.Dto.Password }))
            {
                var user = await userManager.FindByEmailAsync(request.Dto.Email);
                return new SignInInformationDTO
                {
                    Token = await authManager.CreateToken(),
                    UserId = user.Id,
                    Role = userManager.GetRolesAsync(user).Result.First()
                };
            }
            else
                return new SignInInformationDTO();
        }
    }
}
