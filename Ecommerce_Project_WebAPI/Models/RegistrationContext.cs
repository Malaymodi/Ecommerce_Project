using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project_WebAPI.Models
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Registration> registrations { get; set; }
    }
}
