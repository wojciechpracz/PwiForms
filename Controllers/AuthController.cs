using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PwiForms.Services;
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
        private readonly IEmailService _emailService;
        public AuthController(IAuthService authService, IConfiguration config, IEmailService emailService)
        {
            _emailService = emailService;
            _config = config;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegistrationDto userFromRequest)
        {
            var userToRegister = MapUserFromReqToUser(userFromRequest);

            var result = await _authService.RegisterUser(userToRegister);

            if (result)
            {
                _emailService.SendConfimationMail(userToRegister.Email, userToRegister.EmailConfirmationToken);
                return StatusCode(201);
            }

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            var user = await _authService.Login(userForLogin.Email, userForLogin.Password);

            if (user == null)
                return BadRequest();

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

            var userToReturnDetails = new UserToReturnWithDetails
            {
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

            var userToReturn = new UserToReturnFromLogin
            {
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


        private User MapUserFromReqToUser(UserForRegistrationDto userFromReq)
        {
            User user = new User();
            user.City = userFromReq.City;
            user.CountryId = userFromReq.CountryId;
            user.Email = userFromReq.Email;
            user.Name = userFromReq.Name;
            user.Phone = userFromReq.Phone;
            user.PostalCode = userFromReq.PostalCode;
            user.Street = userFromReq.Street;
            user.Surname = userFromReq.Surname;

            user.EmailConfirmationToken = Guid.NewGuid().ToString();
            user.IsActivated = false;

            // var country = _context.Countries.FirstOrDefault(c => c.Id == userFromReq.CountryId);
            // user.Country = country;

            byte[] passwordHash, passwordSalt;
            _authService.CreatePasswordHash(userFromReq.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return user;
        }

        // private bool SendConfirmationEmail(string email, string token)
        // {
        //     var MailMessage = new MailMessage();
        // }
    }
}