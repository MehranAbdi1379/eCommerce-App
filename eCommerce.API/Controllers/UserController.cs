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
        public IActionResult SignUp(SignUpDTO dto)
        {
            return Ok(userService.SignUp(dto));
        }
    }
}
