
using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Runtime.InteropServices;

namespace Ecommerce_Project_WebAPI.Services
{
    public class ProductRepository : IProduct
    {

        private EcommerceContext _context;

        public ProductRepository(EcommerceContext context)
        {
            _context = context;
        }
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            //return _context.Set<Product>().ToList();
          
            return  _context.Product.Include(product => product.ProductImage).ToList();
        }

        public IEnumerable<Product> GetProducts()
        {

            return _context.Product.ToList();

        }

        public async Task<Product> GetProduct(long productid)
        {
            return await _context.Product.FirstOrDefaultAsync(a => a.ProductId == productid);
        }

        //create product
        public async Task<Product> AddProduct(Product product)
        {
            var result = await _context.Product.AddAsync(product);
          //  var imageresult = await _context.ProductImages.AddAsync(new ProductImages() { Product = product });

            await _context.SaveChangesAsync();
            return result.Entity;
            
        }

        //get all products
        public async Task<IEnumerable<Product>> GetAllProductss()
        {
            //return await _context.Product.ToListAsync();
            return await _context.Product.Include(product => product.ProductImage).ToListAsync();

        }

        //update product
         public async Task<Product> UpdateProduct(Product product, long id)
        //public async Task<Product> UpdateProduct(Product product, FindProduct findProduct)
        {

            //  var result = await _context.Product.FirstOrDefaultAsync(a=>a.ProductId == product.ProductId);
            var result = await _context.Product.FindAsync(id);
            if(result != null)
            {
                result.Name = product.Name;
                result.Description = product.Description;
                result.Price = product.Price;
                result.MaxQuantity = product.MaxQuantity;
                result.MinQuantity = product.MinQuantity;
                result.ProductImage = product.ProductImage;
                
                //result.Image = product.Image;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        //delete product
        public async Task<Product> DeleteProduct(long productid)
        {
            var result = await _context.Product.Where(a => a.ProductId == productid).FirstOrDefaultAsync();
            if(result != null)
            {
                _context.Product.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;

        }

       
    }
}
