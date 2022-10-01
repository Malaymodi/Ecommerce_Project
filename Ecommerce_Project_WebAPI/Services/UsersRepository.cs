
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ecommerce_Project_WebAPI.Services
{
    public class UsersRepository : IUsers
    {
        private EcommerceContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;



        public UsersRepository(EcommerceContext context, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        public async Task<Users> AddRegisteredUser(Users users)
        {
            var result = await _context.Users.AddAsync(users);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        

        public async Task<Users> DeleteRegisteredUser(int ruserid)
        {
            var result = await _context.Users.Where(a => a.UserId == ruserid).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Users.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
       
        public async Task<IEnumerable<Users>> GetAllRegisteredUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Users> GetRegisteredUser(int ruserid)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.UserId == ruserid);
        }
        
        public async Task<Users> UpdateRegisteredUser(Users registration)
        {
            var result = await _context.Users.FirstOrDefaultAsync(a => a.UserId == registration.UserId);
            if(result!= null)
            {
                result.FirstName = registration.FirstName;
                result.LastName = registration.LastName;
                result.DOB = registration.DOB;
                result.Email = registration.Email;
                result.Password = result.Password;
                result.ImageUrl = result.ImageUrl;
                result.UserRoleId = result.UserRoleId;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<(bool Succeeded, string[] Errors)> CreateRoleAsync(ApplicationRole role)
        {
           

            

            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());


            role = await _roleManager.FindByNameAsync(role.Name);

            return (true, new string[] { });
        }



    }
}
