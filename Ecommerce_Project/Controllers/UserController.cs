using Ecommerce_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce_Project.Controllers
{
    public class UserController : Controller
    {

        HttpClient client = new HttpClient();
        string Baseurl = "https://localhost:44333";
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(UserLoginViewModel user)
        {
            using(var httpclient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync("https://localhost:44333/api/Authenticate/login", stringContent))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    HttpContext.Session.SetString("JWToken", token);
                    if(token != null)
                    {
                        return RedirectToAction("Create", "Product");
                    }
                }

                return NotFound("User not found.");


            }
            
        }
    }
}
