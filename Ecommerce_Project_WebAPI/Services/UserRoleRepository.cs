using Ecommerce_Project_WebAPI.Migrations.Product;
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce_Project_WebAPI.Services
{
    public class UserRoleRepository : IUserRole
    {
        private UserRoleContext userroleContext;

        public UserRoleRepository(UserRoleContext obj)
        {
            userroleContext = obj;
        }
       
       public async Task<UserRole> AddUserRole(UserRole userRole)
        {
            try
            {

                var result = await userroleContext.UserRoles.AddAsync(userRole);
                await userroleContext.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            
           
        }

        public async Task<UserRole> DeleteUserRole(int roleid)
        {
          var result = await userroleContext.UserRoles.Where(a=>a.Id == roleid).FirstOrDefaultAsync();
          if(result != null)
            {
                userroleContext.UserRoles.Remove(result);
                await userroleContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        

        public async Task<IEnumerable<UserRole>> GetAllUsers()
        {
            return userroleContext.UserRoles.ToList();
        }

        public async Task<UserRole> GetUserRole(int roleid)
        {
            return await userroleContext.UserRoles.FirstOrDefaultAsync(a => a.Id == roleid);
        }

        public async Task<UserRole> UpdateUserRole(UserRole userRole)
        {

            try
            {
                var result = await userroleContext.UserRoles.FirstOrDefaultAsync(a => a.Id == userRole.Id);
                if (result != null)
                {
                    result.RoleName = userRole.RoleName;
                    await userroleContext.SaveChangesAsync();
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

       
    }
}
