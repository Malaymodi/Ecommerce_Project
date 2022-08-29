using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project_WebAPI.Models
{
    public class UserRoleContext : DbContext
    {
        public UserRoleContext(DbContextOptions<UserRoleContext> options) : base(options)
        {

        }

        public DbSet<UserRole> UserRoles { get; set; }
    }
}
