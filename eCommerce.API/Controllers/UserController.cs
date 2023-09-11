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
