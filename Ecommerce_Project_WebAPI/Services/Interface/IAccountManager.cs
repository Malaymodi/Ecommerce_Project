using Ecommerce_Project_WebAPI.IdentityAuth;

namespace Ecommerce_Project_WebAPI.Services.Interface
{
    public interface IAccountManager
    {
        Task<ApplicationUser> GetAuthenticatedUserAsync(string email, string password);
        Task<IList<string>> GetUserRolesAsync(ApplicationUser user);

    }
}
