using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;

namespace Ecommerce_Project_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        /* UserRoleContext _obj;

         public UserRoleController(UserRoleContext obj)
         {
             _obj = obj;
         }

         [HttpGet]
         public List<UserRole> GetUserRoles()
         {
             List<UserRole> ListRoles;
             ListRoles = _obj.Set<UserRole>().ToList();

             return ListRoles;
         }
        */

        private readonly IUserRole _userrole;
        public UserRoleController(IUserRole userRole)
        {
            _userrole = userRole;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await _userrole.GetAllUsers());
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserRole>> GetUserRoleDetails(int id)
        {
            try
            {
                var result = await _userrole.GetUserRole(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from databasedetail");
            }

        }

        [HttpPost]
        public async Task<ActionResult<UserRole>> CreateUser(UserRole userRole)
        {
            try
            {
                if (userRole == null)
                {
                    return BadRequest();
                }

                var createduser = await _userrole.AddUserRole(userRole);
                return CreatedAtAction(nameof(GetUserRoleDetails), new { id = createduser.UserRoleId},createduser);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserRole>> UpdateUserRole(int id, UserRole userrole)
        {
            try
            {
                if (id != userrole.UserRoleId)
                {
                    return BadRequest("Id Mismatch");
                }

                var updateduserrole = await _userrole.GetUserRole(id);
                if (updateduserrole == null)
                {
                    return NotFound($"User Role Id = {id} not found");
                }

                return await _userrole.UpdateUserRole(userrole);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UserRole>> DeleteUserRole(int id)
        {
            try
            {
                var deleteuserrole = await _userrole.GetUserRole(id);
                if (deleteuserrole == null)
                {
                    return NotFound($"Role Id = {id} not found");
                }
                return await _userrole.DeleteUserRole(id);

            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error in retrieving data from database");
            }
        }

    }
}
