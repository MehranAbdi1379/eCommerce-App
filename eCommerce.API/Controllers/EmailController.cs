﻿using eCommerce.Service.Contracts.DTO;
using eCommerce.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Service.Contracts;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace eCommerce.API.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IUserService userService;

        public EmailController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("verify-email")]
        [HttpPut]
        public async Task<IActionResult> VerifyEmail(EmailVerificationDTO dto)
        {
            var result = await userService.VerifyEmail(dto.UserId, dto.Token);
            if (result.Succeeded)
                return Ok();
            return Unauthorized();
        }

        [Route("send-reset-password-email")]
        [HttpGet]
        public void SendPasswordResetEmail([FromQuery] string email)
        {
            userService.SendPasswordResetEmail(email);
        }

        [Route("reset-password")]
        [HttpPut]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO dto)
        {
            var result = await userService.ChangePassword(dto);

            if(result.Succeeded)
                return Ok(result);
            return BadRequest(result);
        }
    }
}