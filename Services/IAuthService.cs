using System.Collections.Generic;
using System.Threading.Tasks;
using pwiforms2.Dtos;
using pwiforms2.Models;

namespace pwiforms2.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(User user);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        Task<IEnumerable<object>> GetAllUsers();
        Task<User> Login(string email, string password);
        
    }
}