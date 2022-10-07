using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.ViewModels
{
    public class ProductViewModel
    {
        public long ProductId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [MaxLength(1000)]
        public string Description { get; set; } = default!;

       // [Precision(14, 2)]
        public decimal Price { get; set; }

        public int MaxQuantity { get; set; }

        public int MinQuantity { get; set; }

        public List<IFormFile>? ProductImages { get; set; }

        //public List<ProductImagesRequestModel> productImage { get; set; }
    }
   public class ProductImagesRequestModel
    {
        public string imageUrl { get; set; } = default!;

        public string ImageName { get; set; } = default!;
    }
   
}
