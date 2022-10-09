using Ecommerce_Project_WebAPI.IdentityAuth;
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;


namespace Ecommerce_Project_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUserRole _userrole;
        private readonly IUserService _registration;
        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUserRole userRole, IUserService registration, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _userrole = userRole;
            _registration = registration;
        }

       // [HttpGet]
        /*public async Task<Users> Authenticate(string Email, string Password)
        {
            var aUser = _registration.GetAuthenticatedUserAsync(Email, Password).Result;
            if (aUser == null)
                return null;

            var user = new Users { };
            {
                user.Email = aUser.Email;
                user.FirstName = aUser.FirstName;
                user.LastName = aUser.LastName;
                user.AspNetUserId = aUser.AspNetUserId;
                user.Password = aUser.Password;
                user.UserRoleId = aUser.UserRoleId;
            }

            var roles = _userrole.GetUserRolesAsync(aUser).Result[0];
            var users = _customerRepository.GetCustomerByUserId(aUser.Id).Result;
        }*/
      


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                if (model.Username == "gurprit@gmail.com")
                {

                    var authClaims = new List<Claim>
                    {
                         new Claim(ClaimTypes.Name, user.UserName),
                         new Claim(ClaimTypes.Role,"Super Admin"),
                         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));

                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT: ValidIssuer"],
                        audience: _configuration["JWT: ValidAudience"],
                        expires: DateTime.Now.AddDays(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });

                }

                else if (model.Username == "parth@gmail.com")
                {



                    var authClaims = new List<Claim>
                    {
                          new Claim(ClaimTypes.Name, user.UserName),
                          new Claim(ClaimTypes.Role,"Admin"),
                          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));

                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT: ValidIssuer"],
                        audience: _configuration["JWT: ValidAudience"],
                        expires: DateTime.Now.AddDays(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                else if (model.Username == "malay@gmail.com")
                {



                    var authClaims = new List<Claim>
                    {
                          new Claim(ClaimTypes.Name, user.UserName),
                          new Claim(ClaimTypes.Role,"customer"),
                          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));

                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT: ValidIssuer"],
                        audience: _configuration["JWT: ValidAudience"],
                        expires: DateTime.Now.AddDays(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }


                /*  var authClaims = new List<Claim>
              {
                  new Claim(ClaimTypes.Name, user.UserName),

                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
              };

                  foreach (var userRole in userRoles)
                  {
                      authClaims.Add(new Claim(ClaimTypes.Role, userRole));

                  }

                  var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

                  var token = new JwtSecurityToken(
                      issuer: _configuration["JWT: ValidIssuer"],
                      audience: _configuration["JWT: ValidAudience"],
                      expires: DateTime.Now.AddDays(1),
                      claims: authClaims,
                      signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                      );

                  return Ok(new
                  {
                      token = new JwtSecurityTokenHandler().WriteToken(token),
                      expiration = token.ValidTo
                  });
                */
            }
              


          
            return Unauthorized();
        }

        
    }
}
