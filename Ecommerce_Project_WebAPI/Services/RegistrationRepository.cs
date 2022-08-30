using Ecommerce_Project_WebAPI.Migrations.Product;
using Ecommerce_Project_WebAPI.Migrations.Registration;
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project_WebAPI.Services
{
    public class RegistrationRepository : IRegistration
    {
        private RegistrationContext registerContext;

        public RegistrationRepository(RegistrationContext obj)
        {
            registerContext = obj;
        }
        public async Task<Registration> AddRegisteredUser(Registration registration)
        {
            var result = await registerContext.registrations.AddAsync(registration);
            await registerContext.SaveChangesAsync();
            return result.Entity;
        }

        

        public async Task<Registration> DeleteRegisteredUser(int ruserid)
        {
            var result = await registerContext.registrations.Where(a => a.ID == ruserid).FirstOrDefaultAsync();
            if (result != null)
            {
                registerContext.registrations.Remove(result);
                await registerContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
       
        public async Task<IEnumerable<Registration>> GetAllRegisteredUsers()
        {
            return await registerContext.registrations.ToListAsync();
        }

        public async Task<Registration> GetRegisteredUser(int ruserid)
        {
            return await registerContext.registrations.FirstOrDefaultAsync(a => a.ID == ruserid);
        }
        
        public async Task<Registration> UpdateRegisteredUser(Registration registration)
        {
            var result = await registerContext.registrations.FirstOrDefaultAsync(a => a.ID == registration.ID);
            if(result!= null)
            {
                result.FirstName = registration.FirstName;
                result.LastName = registration.LastName;
                result.DOB = registration.DOB;
                result.Email = registration.Email;
                result.Password = result.Password;
                result.Photo = result.Photo;
                result.RoleId = result.RoleId;
                await registerContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        

    }
}
