using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce_Project_WebAPI.Models
{
    public class ProductImages
    {
        [Key]
        public int ID { get; set; }


        public string ImageUrl { get; set; } = default!;

        public string ImageName { get; set; } = default!;


        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public Product? Product { get; set; }
     }
}
