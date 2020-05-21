using System.Collections.Generic;
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
            if(_context.Users.FirstOrDefaultAsync(u => u.Email == user.Email) != null)
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
            var userFromDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (userFromDb == null)
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

        public User MapUserFromReqToUser(UserForRegistrationDto userFromReq)
        {
            User user = new User();
            user.City = userFromReq.City;
            user.Country = userFromReq.Country;
            user.Email = userFromReq.Email;
            user.Name = userFromReq.Name;
            user.Phone = userFromReq.Phone;
            user.PostalCode = userFromReq.PostalCode;
            user.Street = userFromReq.Street;
            user.Surname = userFromReq.Surname;

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userFromReq.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return user;

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
            return await _context.Users.ToListAsync();
        }
    }
}