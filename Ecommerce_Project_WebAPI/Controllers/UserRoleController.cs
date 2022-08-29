using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce_Project_WebAPI.Models;

namespace Ecommerce_Project_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        UserRoleContext _obj;

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
    }
}
