using Microsoft.EntityFrameworkCore;
namespace Ecommerce_Project_WebAPI.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            
        }
        public DbSet<Product> products { get; set; }
    }
}
