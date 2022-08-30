using Ecommerce_Project_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Project_WebAPI.Services.Interface
{
    public interface IProduct
    {
        ActionResult<IEnumerable<Product>> GetAllProducts();
        public IEnumerable<Product> GetProducts();

        Task<IEnumerable<Product>> GetAllProductss();

        Task<Product> GetProduct(int productid);
        Task<Product> AddProduct(Product product);

        Task<Product> UpdateProduct(Product product);

        Task<Product> DeleteProduct(int productid);
    }
}
