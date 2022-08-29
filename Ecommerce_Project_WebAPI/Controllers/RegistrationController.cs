using Ecommerce_Project_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Project_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
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
    }
}
