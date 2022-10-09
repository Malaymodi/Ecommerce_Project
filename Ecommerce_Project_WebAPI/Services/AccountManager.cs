using Ecommerce_Project_WebAPI.IdentityAuth;
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_Project_WebAPI.Services
{
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly EcommerceContext _context;
        public AccountManager(
        EcommerceContext context,
        UserManager<ApplicationUser> userManager,
        IHttpContextAccessor httpAccessor)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetAuthenticatedUserAsync(string email, string password)
        {
            return await GetUserByEmailAsync(email);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }
}
