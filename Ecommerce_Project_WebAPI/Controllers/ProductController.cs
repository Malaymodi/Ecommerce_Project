using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Ecommerce_Project_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpGet]
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductDetails(int id)
        {
            try
            {
                var result = await _product.GetProduct(id);
                if(result == null)
                {
                    return NotFound();
                }
                return result;
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }

        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            try
            {
                if(product  == null)
                {
                    return BadRequest();
                }

                var createdproduct = await _product.AddProduct(product);
                return CreatedAtAction(nameof(GetProductDetails), new {id=createdproduct.PId});
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            try
            {
                if(id!=product.PId)
                {
                    return BadRequest("Id Mismatch");
                }

                var updatedproduct = await _product.GetProduct(id);
                if(updatedproduct==null)
                {
                    return NotFound($"Product Id = {id} not found");
                }

                return await _product.UpdateProduct(updatedproduct);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in retrieving data from database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
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
