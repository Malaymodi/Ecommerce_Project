using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project_WebAPI.Models
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [MaxLength(1000)]
        public string Description { get; set; } = default!;

        [Precision(14, 2)]
        public decimal Price { get; set; }

        public int MaxQuantity { get; set; }

        public int MinQuantity { get; set; }

        //[NotMapped]
      //  public IFormFile Image { get; set; }

        public string Created_By { get; set; } = "Malay Modi";

        public DateTime Created_At { get; set; } = DateTime.Now;

        public string Updated_By { get; set; } = "Malay Modi";

        public DateTime Updated_At { get; set; } = DateTime.Now;

       
        public List<ProductImages>? ProductImage { get; set; }

      //  public ProductImages ProductImages { get; set; }   



    }
}
