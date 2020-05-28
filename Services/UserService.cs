using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PwiForms.Dtos;
using pwiforms2.Data;
using pwiforms2.Dtos;
using pwiforms2.Models;

namespace PwiForms.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;

        }

        public async Task<User> UpdateUserData(UserForUpdateDto user)
        {
            var userFromDb = await _context.Users.Include(c => c.Country).FirstOrDefaultAsync(u => u.Id == user.Id);    
            
            if(userFromDb != null)
            {
                userFromDb.Name = user.Name;
                userFromDb.Surname = user.Surname;
                userFromDb.Phone = user.Phone;
                userFromDb.PostalCode = user.PostalCode;
                userFromDb.Street = user.Street;
                userFromDb.City = user.City;
                userFromDb.CountryId = user.CountryId;
            }

            var result = await _context.SaveChangesAsync();

            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == user.CountryId);
            userFromDb.Country = country;

            return userFromDb;

        }

        public async Task<bool> ActivateUser(string email, string token)
        {
            var userFromDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if(userFromDb != null && userFromDb.EmailConfirmationToken == token)
            {
                userFromDb.IsActivated = true;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}