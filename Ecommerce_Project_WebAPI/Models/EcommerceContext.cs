using Ecommerce_Project_WebAPI.IdentityAuth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerce_Project_WebAPI.Models
{
    public class EcommerceContext : IdentityDbContext<ApplicationUser>
    {
        /*public EcommerceContext(DbContextOptions options) : base(options)
        {

        }
        */
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }

         

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<ApplicationRole> AspNetRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
      
    }
}
