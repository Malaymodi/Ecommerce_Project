using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace Ecommerce_Project_WebAPI.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Price { get; set; }

        public int MaxQuantity { get; set; }

        public int MinQuantity { get; set; }

        //[NotMapped]
      //  public IFormFile Image { get; set; }

        public string Created_By { get; set; } = "Malay Modi";

        public DateTime Created_At { get; set; } = DateTime.Now;

        public string Updated_By { get; set; } = "Malay Modi";

        public DateTime Updated_At { get; set; } = DateTime.Now;

        public List<ProductImages> ProductImageList { get; set; }



    }
}
