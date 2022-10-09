
using AutoMapper;
using Ecommerce_Project_WebAPI.APIRequestModels;
using Ecommerce_Project_WebAPI.IdentityAuth;
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Ecommerce_Project_WebAPI.APIRequestModels.UserRequestViewModel;

namespace Ecommerce_Project_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        //   private readonly IMapper _mapper;
        public UserController(UserManager<ApplicationUser> userManager, IUserService registration)
        {
            _userService = registration;
            _userManager = userManager;
            //   _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetRegisteredUsers()
        {
            try
            {
                return Ok(await _userService.GetAllRegisteredUsers());
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }

        }
        //[HttpGet("{id:int}")]
        [HttpGet("[action]")]
        public async Task<ActionResult<Users>> GetRegisteredUserDetails(int id)
        {
            try
            {
                var result = await _userService.GetRegisteredUser(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }

        }

        [HttpPost]
        public async Task<ActionResult<Users>> CreateRegisteredUser([FromForm] CreateUserRequestModel createUserRequest)
        {
            Users users = new Users();
            try
            {
                users.FirstName = createUserRequest.FirstName;
                users.LastName = createUserRequest.LastName;
                users.Email = createUserRequest.Email;
                users.Password = createUserRequest.Password;
                users.ImageUrl = createUserRequest.ImageUrl;


                if (users == null)
                {
                    return BadRequest();
                }

                UserRole userRole = new UserRole();


                ApplicationUser user = new ApplicationUser()
                {
                    Email = createUserRequest.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = createUserRequest.Email
                };

                var result = await _userManager.CreateAsync(user, createUserRequest.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Creation Failed" });
                }

                users.AspNetUserId = user.Id;
                //users.UserRoleId = userRole.UserRoleId;
                users.AspNetUserId = user.Id;

                var createuser = await _userService.AddRegisteredUser(users);
                return CreatedAtAction(nameof(GetRegisteredUserDetails), new { id = createuser.UserId }, createuser);
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }

        }

        //    [HttpPost("roles")]
        /*  public async Task<IActionResult> CreateRole([FromBody] RoleRequestViewModel role)
          {
              if (ModelState.IsValid)
              {
                  if (role == null)
                      return BadRequest($"{nameof(role)} cannot be null");


                  ApplicationRole appRole = _mapper.Map<ApplicationRole>(role);

                  var result = await _registration.CreateRoleAsync(appRole);
                  if (result.Succeeded)
                  {
                      return Ok("Role Added Successfully");
                  }


              }

              return BadRequest(ModelState);
          }*/
        // [HttpPost]
        /*  public async Task<ActionResult<Users>> CreateRegisteredUser(Users registration)
          {
              try
              {
                  if (registration == null)
                  {
                      return BadRequest();
                  }
                  ApplicationUser user = new ApplicationUser()
                  {
                      Email = registration.Email,
                      SecurityStamp = Guid.NewGuid().ToString(),
                      UserName = registration.Email
                  };

                  var result = await _userManager.CreateAsync(user, registration.Password);
                  if (!result.Succeeded)
                  {
                      return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Creation Failed" });
                  }

                  registration.AspNetUserId = user.Id;


                  var createdregistreduser = await _registration.AddRegisteredUser(registration);
                //  return Ok(new Response { Status = "Success", Message = "User Created Successfully" });

                 // var createdregistreduser = await _registration.AddRegisteredUser(registration);
                  return CreatedAtAction(nameof(GetRegisteredUserDetails), new { id = createdregistreduser.UserId }, createdregistreduser);


              }
              catch
              {
                  return StatusCode(StatusCodes.Status500InternalServerError,
                      "Error in retrieving data from database");
              }
          }*/



        [HttpPut("{id:int}")]
        public async Task<ActionResult<Users>> UpdateRegisteredUser(int id, Users users)
        {
            try
            {
                if (id != users.UserId)
                {
                    return BadRequest("Id Mismatch");
                }

                var updatedregistereduser = await _userService.GetRegisteredUser(id);
                if (updatedregistereduser == null)
                {
                    return NotFound($"Registered User Id = {id} not found");
                }

                return await _userService.UpdateRegisteredUser(users);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Users>> DeleteRegisteredUser(int id)
        {
            try
            {
                var deleteregistereduser = await _userService.GetRegisteredUser(id);
                if (deleteregistereduser == null)
                {
                    return NotFound($"Registered User Id = {id} not found");
                }
                return await _userService.DeleteRegisteredUser(id);

            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error in retrieving data from database");
            }
        }

        /*
        RegistrationContext _obj;

        public RegistrationController(RegistrationContext obj)
        {
            _obj = obj;
        }

        [HttpGet]
        public List<Registration> GetUser()
        {
            List<Registration> ListRoles;
            ListRoles = _obj.Set<Registration>().ToList();

            return ListRoles;
        }
        */


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserLoginModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password).Result;

            if (user == null)
                return BadRequest(new { message = "The email and/or password you entered does not match our records. Please try again." });
            else
            {
                return Ok(user);
            }
        }

    }
}
