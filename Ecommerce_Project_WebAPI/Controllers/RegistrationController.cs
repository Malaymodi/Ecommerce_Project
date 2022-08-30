using Ecommerce_Project_WebAPI.Migrations.Product;
using Ecommerce_Project_WebAPI.Migrations.Registration;
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Project_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        private readonly IRegistration _registration;
        public RegistrationController(IRegistration registration)
        {
            _registration = registration;
        }

        [HttpGet]
        public async Task<ActionResult> GetRegisteredUsers()
        {
            try
            {
                return Ok(await _registration.GetAllRegisteredUsers());
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Registration>> GetRegisteredUserDetails(int id)
        {
            try
            {
                var result = await _registration.GetRegisteredUser(id);
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
        public async Task<ActionResult<Registration>> CreateRegisteredUser(Registration registration)
        {
            try
            {
                if (registration == null)
                {
                    return BadRequest();
                }

                var createdregistreduser = await _registration.AddRegisteredUser(registration);
                return CreatedAtAction(nameof(GetRegisteredUserDetails), new { id = createdregistreduser.ID });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Registration>> UpdateProduct(int id, Registration registration)
        {
            try
            {
                if (id != registration.ID)
                {
                    return BadRequest("Id Mismatch");
                }

                var updatedregistereduser = await _registration.GetRegisteredUser(id);
                if (updatedregistereduser == null)
                {
                    return NotFound($"Registered User Id = {id} not found");
                }

                return await _registration.UpdateRegisteredUser(updatedregistereduser);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Registration>> DeleteRegisteredUser(int id)
        {
            try
            {
                var deleteregistereduser = await _registration.GetRegisteredUser(id);
                if (deleteregistereduser == null)
                {
                    return NotFound($"Registered User Id = {id} not found");
                }
                return await _registration.DeleteRegisteredUser(id);

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
    }
}
