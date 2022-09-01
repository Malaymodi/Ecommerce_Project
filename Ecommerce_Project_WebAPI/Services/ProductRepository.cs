using Ecommerce_Project_WebAPI.Migrations.Product;
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Ecommerce_Project_WebAPI.Services
{
    public class ProductRepository : IProduct
    {

        private ProductContext productContext;

        public ProductRepository(ProductContext obj)
        {
            productContext = obj;
        }
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return productContext.Set<Product>().ToList();
        }

        public IEnumerable<Product> GetProducts()
        {

            return productContext.products.ToList();

        }

        public async Task<Product> GetProduct(int productid)
        {
            return await productContext.products.FirstOrDefaultAsync(a => a.PId == productid);
        }

        public async Task<Product> AddProduct(Product product)
        {
            var result = await productContext.products.AddAsync(product);
            await productContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<IEnumerable<Product>> GetAllProductss()
        {
            return await productContext.products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await productContext.products.FirstOrDefaultAsync(a=>a.PId == product.PId);
            if(result != null)
            {
                result.Name = product.Name;
                result.Description = product.Description;
                result.Price = product.Price;
                result.MaxQuantity = product.MaxQuantity;
                result.MinQuantity = product.MinQuantity;
                //result.Image = product.Image;
                await productContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Product> DeleteProduct(int productid)
        {
            var result = await productContext.products.Where(a => a.PId == productid).FirstOrDefaultAsync();
            if(result != null)
            {
                productContext.products.Remove(result);
                await productContext.SaveChangesAsync();
                return result;
            }
            return null;

        }
    }
}
