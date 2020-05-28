using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PwiForms.Dtos;
using PwiForms.Services;
using pwiforms2.Dtos;

namespace PwiForms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserForUpdateDto user)
        {
            var userFromDb = await _userService.UpdateUserData(user);

            if (userFromDb != null)
            {                       
                var userToReturnDetails = new UserToReturnWithDetails {
                    Id = userFromDb.Id,
                    Name = userFromDb.Name,
                    Surname = userFromDb.Surname,
                    Email = userFromDb.Email,
                    Street = userFromDb.Street,
                    PostalCode = userFromDb.PostalCode,
                    City = userFromDb.City,
                    Country = userFromDb.Country,
                    CountryId = userFromDb.CountryId,
                    Phone = userFromDb.Phone,
                };

                return Ok(userToReturnDetails);
            }


            return BadRequest();
        }

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var result = await _userService.ActivateUser(email, token);

            if(result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}