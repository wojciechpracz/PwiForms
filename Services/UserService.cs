using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PwiForms.Dtos;
using PwiForms.Models;
using pwiforms2.Data;
using pwiforms2.Dtos;
using pwiforms2.Models;
using pwiforms2.Services;

namespace PwiForms.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;
        public UserService(DataContext context, IEmailService emailService, IAuthService authService)
        {
            _authService = authService;
            _emailService = emailService;
            _context = context;

        }

        public async Task<User> UpdateUserData(UserForUpdateDto user)
        {
            var userFromDb = await _context.Users.Include(c => c.Country).FirstOrDefaultAsync(u => u.Id == user.Id);

            if (userFromDb != null)
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

            if (userFromDb != null && userFromDb.EmailConfirmationToken == token)
            {
                userFromDb.IsActivated = true;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> MakeNewPasswordResestRequest(string email)
        {
            var passwordReset = new PasswordReset();
            var token = Guid.NewGuid().ToString();
            passwordReset.Email = email;
            passwordReset.Token = token;

            _emailService.SendPasswordResetEmail(email, token);

            await _context.PasswordResets.AddAsync(passwordReset);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PasswordReset> GetPasswordReset(string email, string token)
        {
            var passwordReset = await _context.PasswordResets
                .FirstOrDefaultAsync(p => p.Email == email && p.Token == token);

            if (passwordReset != null)
            {
                return passwordReset;
            }

            return null;
        }

        public async Task<bool> ChangeUserPassword(string email, string newPassword)
        {
            var userFromDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (userFromDb != null)
            {
                byte[] passwordHash, passwordSalt;
                _authService.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);

                userFromDb.PasswordHash = passwordHash;
                userFromDb.PasswordSalt = passwordSalt;

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}