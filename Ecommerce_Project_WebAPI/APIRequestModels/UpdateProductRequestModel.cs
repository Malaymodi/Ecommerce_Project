using System.ComponentModel.DataAnnotations;



namespace Ecommerce_Project_WebAPI.APIRequestModelS
{
    public class UpdateProductRequestModel
    {



        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [MaxLength(1000)]
        public string Description { get; set; } = default!;


        public decimal Price { get; set; }

        public int MaxQuantity { get; set; }

        public int MinQuantity { get; set; }

        //[NotMapped]
        //  public IFormFile Image { get; set; }

        public List<IFormFile> ProductImages { get; set; }
        
    }

    
    public class ProductImages
    {
        public string ImageUrl { get; set; } = default!;

        public string ImageName { get; set; } = default!;
    }

}


