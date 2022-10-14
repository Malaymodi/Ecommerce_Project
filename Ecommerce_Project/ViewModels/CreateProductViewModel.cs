using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.ViewModels
{
    public class CreateProductViewModel
    {
        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [MaxLength(1000)]
        public string Description { get; set; } = default!;


        public decimal Price { get; set; }

        public int MaxQuantity { get; set; }

        public int MinQuantity { get; set; }

        public List <producttest> valuetest { get; set; }

        public List<CreateProductImageViewModel> ProductImagess { get; set; }
     //   public List<ProductImagesRequestModels> ProductImagess { get; set; }

        public List<IFormFile> ProductImages { get; set; }
    }

    public class producttest
    {
        public string test { get; set; } = "test value";

    }
    public class CreateProductImageViewModel
    {
        public string ImageUrl { get; set; } = default!;

        public string ImageName { get; set; } = default!;
    }
}
