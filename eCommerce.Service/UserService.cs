using eCommerce.Service.Contracts;
using eCommerce.Service.Contracts.DTO;
using Framework.Authentication.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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

        public UserService(UserManager<IdentityUser> userManager , IConfiguration configuration)
        {
            this.userManager = userManager;
            this.authManager = new AuthManager(userManager , configuration);
        }

        public async Task<IdentityResult> SignUp(SignUpDTO dto)
        {
            var user = new IdentityUser()
            {
                Email = dto.Email,
                UserName = dto.Email
            };
            var result = await userManager.CreateAsync(user, dto.Password);

            return result;
        }

        public async Task<SignInInformationDTO> SignIn(SignUpDTO dto)
        {
            if (await authManager.ValidateUser(new UserSignInDTO{ Email=dto.Email , Password = dto.Password}))
            {
                return new SignInInformationDTO
                {
                    Token = await authManager.CreateToken(),
                    UserId = userManager.FindByEmailAsync(dto.Email).Result.Id
                };
            }
            return null;
        }
    }
}
