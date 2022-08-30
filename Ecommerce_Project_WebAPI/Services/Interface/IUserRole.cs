using Ecommerce_Project_WebAPI.Models;

namespace Ecommerce_Project_WebAPI.Services.Interface
{
    public interface IUserRole
    {
        Task<IEnumerable<UserRole>> GetAllUsers();

        Task<UserRole> GetUserRole(int roleid);
        Task<UserRole> AddUserRole(UserRole userRole);

        Task<UserRole> UpdateUserRole(UserRole userRole);

        Task<UserRole> DeleteUserRole(int roleid);
    }
}
