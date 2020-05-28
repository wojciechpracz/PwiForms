using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pwiforms2.Data;
using pwiforms2.Dtos;
using pwiforms2.Models;

namespace pwiforms2.Services
{
    public class AuthService: IAuthService
    {
        private readonly DataContext _context;
        public AuthService(DataContext context)
        {
            this._context = context;
        }

        public async Task<bool> RegisterUser(User user)
        { 
            if(await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email) != null)
            {
                return false;
            }
            
            await _context.Users.AddAsync(user);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            } 

            return false;
        }

        public async Task<User> Login(string email, string password)
        {
            var userFromDb = await _context.Users.Include(c => c.Country).FirstOrDefaultAsync(u => u.Email == email);

            if (userFromDb == null || !userFromDb.IsActivated)
            {
                return null;
            }

            var passwordIsCorrect = VerifyPassword(password, userFromDb.PasswordHash, userFromDb.PasswordSalt);

            if(passwordIsCorrect)
            {
                return userFromDb;
            }

            return null;

        }

        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordHashFromLogin = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHashFromLogin[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            } 
        }

        public async Task<IEnumerable<object>> GetAllUsers()
        {
            return await _context.Users.Include(c => c.Country).ToListAsync();
        }
    }
}