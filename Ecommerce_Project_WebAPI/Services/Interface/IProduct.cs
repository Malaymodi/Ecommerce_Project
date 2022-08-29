using Ecommerce_Project_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Project_WebAPI.Services.Interface
{
    public interface IProduct
    {
        ActionResult<IEnumerable<Product>> GetAllProducts();
        IEnumerable<Product> GetProducts();
    }
}
