using eCommerce.Service;
using eCommerce.Service.Contracts;
using eCommerce.Service.Contracts.DTO;
using Framework.Authentication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly AuthManager authManager;

        public UserController(IUserService userService, UserManager<IdentityUser> userManager , IConfiguration configuration)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.authManager = new AuthManager(userManager , configuration);
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
