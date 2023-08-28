using eCommerce.Service.Contracts.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Contracts
{
    public interface IUserService
    {
        public IdentityResult SignUp(SignUpDTO dto);
    }
}
