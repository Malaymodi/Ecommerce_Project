using Ecommerce_Project_WebAPI.IdentityAuth;
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce_Project_WebAPI.Services
{
    public class UserRoleRepository : IUserRole
    {
        private EcommerceContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRoleRepository(EcommerceContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
        }
       
       public async Task<UserRole> AddUserRole(UserRole userRole)
        {
            try
            {
                var result = await _context.UserRole.AddAsync(userRole);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserRole> DeleteUserRole(int roleid)
        {
          var result = await _context.UserRole.Where(a=>a.UserRoleId == roleid).FirstOrDefaultAsync();
          if(result != null)
            {
                _context.UserRole.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        

        public async Task<IEnumerable<UserRole>> GetAllUsers()
        {
            return _context.UserRole.ToList();
        }

        public async Task<UserRole> GetUserRole(int roleid)
        {
            return await _context.UserRole.FirstOrDefaultAsync(a => a.UserRoleId == roleid);
        }

        public async Task<UserRole> UpdateUserRole(UserRole userRole)
        {

            try
            {
                var result = await _context.UserRole.FirstOrDefaultAsync(a => a.UserRoleId == userRole.UserRoleId);
                if (result != null)
                {
                    result.RoleName = userRole.RoleName;
                    await _context.SaveChangesAsync();
                    return result;
                }
                return null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            // return null;
        }

       /* public async Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }*/

    }
}
