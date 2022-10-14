using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.ViewModels
{
    public class CreateProductRequestModel
    {
        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [MaxLength(1000)]
        public string Description { get; set; } = default!;

        public decimal Price { get; set; }

        public int MaxQuantity { get; set; }

        public int MinQuantity { get; set; }

        public List<ProductImagesRequestModels> ProductImagess { get; set; }
        // public List<CreateProductImagerequestViewModel> ProductImages { get; set; }
    }
    public class ProductImagesRequestModels
    {
        public string ImageUrl { get; set; } = default!;

        public string ImageName { get; set; } = default!;
    }
}
