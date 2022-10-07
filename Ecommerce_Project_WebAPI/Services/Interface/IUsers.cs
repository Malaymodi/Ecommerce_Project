using Ecommerce_Project_WebAPI.Models;

namespace Ecommerce_Project_WebAPI.Services.Interface
{
    public interface IUsers
    {
        Task<IEnumerable<Users>> GetAllRegisteredUsers();

        Task<Users> GetRegisteredUser(int ruserid);
        Task<Users> AddRegisteredUser(Users registration);

        Task<Users> UpdateRegisteredUser(Users registration);

        Task<Users> DeleteRegisteredUser(int ruserid);

       // Task<(bool Succeeded, string[] Errors)> CreateRoleAsync(ApplicationRole role);

        // Task<Users> GetAuthenticatedUserAsync(string email, string password);
    }
}
