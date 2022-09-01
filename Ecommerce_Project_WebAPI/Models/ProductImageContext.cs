using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project_WebAPI.Models
{
    public class ProductImageContext : DbContext
    {
        public ProductImageContext(DbContextOptions<ProductImageContext> options) : base(options)
        {

        }
        DbSet<ProductImages> images { get; set; }
    }
}
