using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IConfiguration _config;
        public AuthController(IAuthService authService, IConfiguration config)
        {
            this._config = config;
            this._authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegistrationDto userFromRequest)
        {
            var userToRegister = _authService.MapUserFromReqToUser(userFromRequest);

            var result = await _authService.RegisterUser(userToRegister);

            if (result)
            {
                return StatusCode(201);
            }

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            var user = await _authService.Login(userForLogin.Email, userForLogin.Password);

            if (user == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var secretKey = _config.GetSection("AppSettings:Token").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            var userToReturnDetails = new UserToReturnWithDetails {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Street = user.Street,
                PostalCode = user.PostalCode,
                City = user.City,
                Country = user.Country,
                CountryId = user.CountryId,
                Phone = user.Phone,
            };

            var userToReturn = new UserToReturnFromLogin {
                UserDetails = userToReturnDetails,
                Token = tokenHandler.WriteToken(token)
            };

            return Ok(userToReturn);
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetUsers()
        {
            return await _authService.GetAllUsers();
        }
    }
}