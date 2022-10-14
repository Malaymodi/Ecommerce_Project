using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce_Project.ViewModels
{
    public class Products
    {
        public long ProductId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [MaxLength(1000)]
        public string Description { get; set; } = default!;

        [Precision(14, 2)]
        public decimal Price { get; set; }

        public string? searchString { get; set; }

        //  public List<IFormFile> imageurl { get; set; }

        public ProductImagesModel[] ProductImages { get; set; }
    }

    public class ProductImagesModel
    {
        public string imageUrl { get; set; } = default!;

        public string ImageName { get; set; } = default!;
    }
}
