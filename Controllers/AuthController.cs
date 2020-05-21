using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pwiforms2.Dtos;
using pwiforms2.Models;
using pwiforms2.Services;

namespace pwiforms2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegistrationDto userFromRequest)
        {
            var userToRegister = _authService.MapUserFromReqToUser(userFromRequest);

            var result = await _authService.RegisterUser(userToRegister);

            if(result)
            {
                return StatusCode(201);
            }

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            var user = await _authService.Login(userForLogin.Email, userForLogin.Password);

            if(user == null)
            {
                return BadRequest();
            }

            return Ok(user);

        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetUsers()
        {
            return await _authService.GetAllUsers();
        }
    }
}