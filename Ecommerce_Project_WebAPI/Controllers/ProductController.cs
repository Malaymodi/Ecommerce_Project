using Ecommerce_Project_WebAPI.APIRequestModels;
using Ecommerce_Project_WebAPI.APIRequestModelS;
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using ProductImages = Ecommerce_Project_WebAPI.Models.ProductImages;

namespace Ecommerce_Project_WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("/api/v1/[controller]")]
    //[Route("api/[controller]/[action]/{id}")]

    //[System.Web.Http.RoutePrefix("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        private readonly EcommerceContext _ecommerceContext;
        public ProductController(IProduct product, EcommerceContext ecommerceContext)
        {
            _product = product;
            _ecommerceContext = ecommerceContext;
        }

        [HttpGet("[action]")]
        //[Route("api/product/GetProducts/")]
        // [Route("api/[controller]/[action]")]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                return Ok(await _product.GetAllProductss());
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }

        }
        [HttpGet("[action]")]
        //  [HttpGet("api/{controller}/{action}/{id:int}")]
        // [Route("api/{controller}/{action}/{id}")]
        //  [Route("api/product/GetProductDetails/id")]
        //[Route("api/product/GetProductDetails/{id:int}")]
        public async Task<ActionResult> GetProductDetails(long id)
        {
            try
            {
                var result = await _product.GetProduct(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }

        //[HttpPost]
        [HttpPost("[action]")]
        [Authorize(Roles = "Super Admin, Admin")]
     

        public async Task<ActionResult<Product>> CreateProduct([FromForm] CreateProductRequestModel product)
        {
            Product objProduct = new Product();
            ProductImages objproductImages = new ProductImages();

            try
            {
                objProduct.Name = product.Name;
                objProduct.Description = product.Description;
                objProduct.Price = product.Price;
                objProduct.MinQuantity = product.MinQuantity;
                objProduct.MaxQuantity = product.MaxQuantity;
                List<ProductImages> images = new List<ProductImages>();

                foreach (IFormFile imageFile in product.ProductImages)
                {
                    
                    Guid id = Guid.NewGuid();   
                    string imageName = id.ToString()+"_" + imageFile.FileName+ Path.GetExtension(imageFile.FileName);
                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", imageName);

                    using (var stream = System.IO.File.Create(SavePath))
                    {
                        imageFile.CopyTo(stream);
                    }
                    var img = new ProductImages
                    {
                        ImageUrl = imageName,
                        ImageName = imageFile.FileName,
                    };
                    images.Add(img);
                    
                }
                
                objProduct.ProductImage = images;



                if (product == null)
                {
                    return BadRequest();
                }

                var createdproduct = await _product.AddProduct(objProduct);

                return CreatedAtAction(nameof(GetProductDetails), new { id = createdproduct.ProductId }, createdproduct);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }

        /* [Authorize(Roles = "Super Admin, Admin")]
         [HttpPost]
         public async Task<ActionResult<Product>> CreateProduct(Product product)
         {
             try
             {
                 if (product == null)
                 {
                     return BadRequest();
                 }

                 var createdproduct = await _product.AddProduct(product);
                 return CreatedAtAction(nameof(GetProductDetails), new { id = createdproduct.ProductId }, createdproduct);
             }
             catch
             {
                 return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error in retrieving data from database");
             }
         }
         */

        //[Authorize(Roles = "Super Admin, Admin")]
         [HttpPut("{id:int}")]
        
      
        //[Route("api/product/UpdateProduct/id")]

        // public async Task<ActionResult<Product>> UpdateProduct(long id, Product updateproduct)
        public async Task<ActionResult<Product>> UpdateProduct( long id, [FromForm] UpdateProductRequestModel updateproduct)
        {

            Product objProduct = new Product();
            var findproduct = await _ecommerceContext.Product.FindAsync(id);


            try
            {
                if (id != findproduct.ProductId)
                {
                    return BadRequest("Id Mismatch");
                }

                var updatedproduct = await _product.GetProduct(id);
                if (updatedproduct == null)
                {
                    return NotFound($"Product Id = {id} not found");
                }
                 objProduct.Name = updateproduct.Name;
                 objProduct.Description = updateproduct.Description;
                 objProduct.Price = updateproduct.Price;
                 objProduct.MinQuantity = updateproduct.MinQuantity;
                 objProduct.MaxQuantity = updateproduct.MaxQuantity;
                 List<ProductImages> images = new List<ProductImages>();
                foreach (IFormFile imageFile in updateproduct.ProductImages)
                {

                    Guid uid = Guid.NewGuid();
                    string imageName = uid.ToString() + "_" + imageFile.FileName + Path.GetExtension(imageFile.FileName);
                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", imageName);

                    using (var stream = System.IO.File.Create(SavePath))
                    {
                        imageFile.CopyTo(stream);
                    }
                    var img = new ProductImages
                    {
                        ImageUrl = imageName,
                        ImageName = imageFile.FileName,
                    };
                    images.Add(img);

                }

                objProduct.ProductImage = images;



                return Ok(await _product.UpdateProduct(objProduct, findproduct.ProductId));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }
        [Authorize(Roles = "Super Admin, Admin")]
        //[HttpDelete("{id:int}")]
        [HttpDelete("[action]")]
      //  [Route("api/product/DeleteProduct/id")]

        public async Task<ActionResult<Product>> DeleteProduct(long id)
        {
            try
            {
                var deleteproduct = await _product.GetProduct(id);
                if (deleteproduct == null)
                {
                    return NotFound($"Product Id = {id} not found");
                }
                return await _product.DeleteProduct(id);

            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error in retrieving data from database");
            }
        }
    }
}
