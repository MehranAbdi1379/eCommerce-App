using eCommerce.Service;
using eCommerce.Service.Contracts;
using eCommerce.Service.Contracts.DTO;
using Framework.Authentication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;

namespace eCommerce.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly AuthManager authManager;
        private readonly IEmailService emailService;

        public UserController(IUserService userService, UserManager<IdentityUser> userManager , IConfiguration configuration , IEmailService emailService)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.authManager = new AuthManager(userManager , configuration);
            this.emailService = emailService;
        }
        [Route("sign-up")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDTO dto)
        {
            try
            {
                return Ok(await userService.SignUp(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("send-email")]
        [HttpGet]
        public async Task<IActionResult> SendEmail()
        {
            emailService.Send("Papercut@user.com", "Verify", "Please verify your email");
            return Ok();
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

        [Route("sign-in")]
        [HttpGet]
        public async Task<IActionResult> SignIn([FromQuery] SignUpDTO dto)
        {
            var signInInformation = await userService.SignIn(dto);
            if (signInInformation!= null)
            {
                return Ok(signInInformation);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
