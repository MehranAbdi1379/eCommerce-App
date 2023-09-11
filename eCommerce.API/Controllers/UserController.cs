using eCommerce.Service.Contracts;
using eCommerce.Service.Contracts.DTO;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [Route("sign-up")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDTO dto)
        {
            var result = await userService.SignUp(dto);
            if (result.Succeeded)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [Route("sign-in")]
        [HttpGet]
        public async Task<IActionResult> SignIn([FromQuery] SignUpDTO dto)
        {
            var signInInformation = await userService.SignIn(dto);
            if (signInInformation.Token != null)
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
