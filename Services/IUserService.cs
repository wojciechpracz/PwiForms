using System.Threading.Tasks;
using PwiForms.Dtos;
using pwiforms2.Models;

namespace PwiForms.Services
{
    public interface IUserService
    {
        Task<User> UpdateUserData(UserForUpdateDto user);
        Task<bool> ActivateUser(string email, string token);
    } 
}