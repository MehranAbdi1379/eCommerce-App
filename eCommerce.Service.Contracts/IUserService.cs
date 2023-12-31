﻿using eCommerce.Service.Contracts.DTO;
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
        public Task<IdentityResult> SignUp(SignUpDTO dto);
        public Task<SignInInformationDTO> SignIn(SignInDTO dto);
        public Task<IdentityResult> VerifyEmail(string userId, string token);
        public Task<Task> SendPasswordResetEmail(string email);
        public Task<IdentityResult> ChangePassword(ResetPasswordDTO dto);


    }
}
