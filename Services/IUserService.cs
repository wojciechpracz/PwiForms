using System.Threading.Tasks;
using PwiForms.Dtos;
using PwiForms.Models;
using pwiforms2.Models;

namespace PwiForms.Services
{
    public interface IUserService
    {
        Task<User> UpdateUserData(UserForUpdateDto user);
        Task<bool> ActivateUser(string email, string token);
        Task<bool> MakeNewPasswordResestRequest(string email);
        Task<PasswordReset> GetPasswordReset(string email, string token);
        Task<bool> ChangeUserPassword(string email, string newPassword);
    } 
}