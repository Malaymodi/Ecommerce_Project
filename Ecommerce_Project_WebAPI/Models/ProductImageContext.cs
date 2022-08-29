using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project_WebAPI.Models
{
    public class ProductImageContext : DbContext
    {
        public ProductImageContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<ProductImages> images { get; set; }
    }
}
