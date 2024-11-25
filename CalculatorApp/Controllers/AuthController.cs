using Microsoft.AspNetCore.Mvc;
using CalculatorApp.Models;
using CalculatorApp.Services;

namespace CalculatorApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            if (!_authenticationService.ValidateUser(userLogin.Username, userLogin.Password))
            {
                return Unauthorized();
            }

            var token = _authenticationService.GenerateJwtToken(userLogin.Username);
            return Ok(new { AccessToken = token });
        }
    }
}
