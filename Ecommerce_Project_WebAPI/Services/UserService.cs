﻿
using Ecommerce_Project_WebAPI.Entities;
using Ecommerce_Project_WebAPI.Helpers;
using Ecommerce_Project_WebAPI.IdentityAuth;
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;

namespace Ecommerce_Project_WebAPI.Services
{
    public class UserService : IUserService
    {
        private EcommerceContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountManager _accountManager;
        private readonly AppSettings _appSettings;



        public UserService(UserManager<ApplicationUser> userManager, EcommerceContext context, IAccountManager accountManager,RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _accountManager = accountManager;

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

        public async Task<Users> GetRegisteredUser(long ruserid)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.UserId == ruserid);
            
              
                
            //return await _context.Product.Include(product => product.ProductImage).ToListAsync();

        }

       /* public Task<ApplicationUser> GetUserRole(string id)
        {
            return (Task<ApplicationUser>)_context.UserRoles.Where(r => r.UserId == id);
           // return _context.Users.Where(c => c.AspNetUserId == id).SingleOrDefaultAsync();
        }*/

        /*public Task<ApplicationUser> GetUserRoleId(string id)
        {
            return (Task<ApplicationUser>)_context.UserRoles.Where(s=> s.RoleId == id);
            // return _context.Users.Where(c => c.AspNetUserId == id).SingleOrDefaultAsync();
        }*/
        /*public Task<ApplicationUser> GetUserRoleName(string id)
        {
            return (Task<ApplicationUser>)_context.UserRoles.Where(s => s. == id);
            // return _context.Users.Where(c => c.AspNetUserId == id).SingleOrDefaultAsync();
        }*/

        public async Task<Users> UpdateRegisteredUser(Users registration)
        {
            var result = await _context.Users.FirstOrDefaultAsync(a => a.UserId == registration.UserId);
            if (result != null)
            {
                result.FirstName = registration.FirstName;
                result.LastName = registration.LastName;
              //  result.DOB = registration.DOB;
                result.Email = registration.Email;
                result.Password = result.Password;
                result.ImageUrl = result.ImageUrl;
                result.DOB = registration.DOB;
                //  result.UserRoleId = result.UserRoleId;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        /* public async Task<(bool Succeeded, string[] Errors)> CreateRoleAsync(ApplicationRole role)
         {




             var result = await _roleManager.CreateAsync(role);
             if (!result.Succeeded)
                 return (false, result.Errors.Select(e => e.Description).ToArray());


             role = await _roleManager.FindByNameAsync(role.Name);

             return (true, new string[] { });
         }
        */

        public async Task<User> Authenticate(string username, string password)
        {
            var aUser = _accountManager.GetAuthenticatedUserAsync(username, password).Result;
            //aUser.EmailConfirmed
            //aUser.AccountNumberVerified
            //aUser.CompanyNameVerified

            // return null if user not found
            if (aUser == null)
                return null;
            var user = new User { };
            user.Email = aUser.Email;
            user.Id = aUser.Id;
            user.FirstName = aUser.FirstName;
            user.LastName = aUser.LastName;



            //TODO: Fix
            var roles = _accountManager.GetUserRolesAsync(aUser).Result[0];
            var _user = GetUserByAspNetUserId(aUser.Id).Result;


            user.Role = roles;
            user.UserId = _user.UserId;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Lorem ipsum dolor sit amet o0 consectetur adipiscing elit Curabitur suscipit");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }
        public Task<Ecommerce_Project_WebAPI.Models.Users> GetUserByAspNetUserId(string id)
        {
            return _context.Users.Where(c => c.AspNetUserId == id).SingleOrDefaultAsync();
        }
    }
}
