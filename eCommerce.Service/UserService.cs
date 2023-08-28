using eCommerce.Service.Contracts;
using eCommerce.Service.Contracts.DTO;
using Microsoft.AspNetCore.Identity;
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

        public UserService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public IdentityResult SignUp(SignUpDTO dto)
        {
            var user = new IdentityUser()
            {
                Email = dto.Email,
                UserName = dto.Email
            };
            var result = userManager.CreateAsync(user, dto.Password).Result;

            return result;
        }
    }
}
