using Ecommerce_Project_WebAPI.Entities;
using Ecommerce_Project_WebAPI.Models;

namespace Ecommerce_Project_WebAPI.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<Users>> GetAllRegisteredUsers();

        Task<Users> GetRegisteredUser(long ruserid);
        Task<Users> AddRegisteredUser(Users registration);

        Task<Users> UpdateRegisteredUser(Users registration);

        Task<Users> DeleteRegisteredUser(int ruserid);

        // Task<(bool Succeeded, string[] Errors)> CreateRoleAsync(ApplicationRole role);

        // Task<Users> GetAuthenticatedUserAsync(string email, string password);
        Task<User> Authenticate(string username, string password);

        Task<Users> GetUserByAspNetUserId(string id);
    }
}
