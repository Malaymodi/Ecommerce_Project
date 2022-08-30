using Ecommerce_Project_WebAPI.Models;

namespace Ecommerce_Project_WebAPI.Services.Interface
{
    public interface IRegistration
    {
        Task<IEnumerable<Registration>> GetAllRegisteredUsers();

        Task<Registration> GetRegisteredUser(int ruserid);
        Task<Registration> AddRegisteredUser(Registration registration);

        Task<Registration> UpdateRegisteredUser(Registration registration);

        Task<Registration> DeleteRegisteredUser(int ruserid);
    }
}
