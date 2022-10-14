using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce_Project_WebAPI.APIRequestModelS;
using Microsoft.AspNetCore.Http;
namespace Ecommerce_Project_WebAPI.APIRequestModels;

public class CreateProductRequestModel
{
  
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    [MaxLength(1000)]
    public string Description { get; set; } = default!;

    
    public decimal Price { get; set; }

    public int MaxQuantity { get; set; }

    public int MinQuantity { get; set; }

    public List<CreateProductImageViewModel> ProductImagess { get; set; }
    public List<IFormFile> ProductImages { get; set; }

    public List<producttest> valuetest { get; set; }

 
}

  public class CreateProductImageViewModel
{
    public string ImageUrl { get; set; } = default!;

    public string ImageName { get; set; } = default!;
}

   public class producttest
{
    public string test { get; set; } = default!;

}


public class ProductImagesRequestModels
{
    public string ImageUrl { get; set; } = default!;

    public string ImageName { get; set; } = default!;
}

