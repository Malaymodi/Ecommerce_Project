using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
