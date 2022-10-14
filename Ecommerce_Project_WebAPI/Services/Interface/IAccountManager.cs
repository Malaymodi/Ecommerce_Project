using Ecommerce_Project_WebAPI.IdentityAuth;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_Project_WebAPI.Services.Interface
{
    public interface IAccountManager
    {
        Task<ApplicationUser> GetAuthenticatedUserAsync(string email, string password);
        Task<IList<string>> GetUserRolesAsync(ApplicationUser user);

        Task<IdentityResult> AssignRoleToUser(ApplicationUser user, string role);

    }
}
