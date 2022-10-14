using Ecommerce_Project.Models;
using Ecommerce_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Ecommerce_Project.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();
        string Baseurl = "https://localhost:44333";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public async Task<ActionResult> Index(string searchString)
        {
            List<Products> products = new List<Products>();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            string url = "api/Product";
            var Res = await client.GetAsync("/api/v1/Product/GetProducts");
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Products>>(Response);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                var searchproduct = products.Where(p => p.Name.Contains(searchString));
                return View(searchproduct);
            }


            return View(products);
           // return RedirectToAction("index", "Home", products);
        }
        public async Task<ActionResult> Details(int id)
        {
            UserProductViewModel userProductViewModel = new UserProductViewModel();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            string url = "api/Product";
            HttpResponseMessage Res = await client.GetAsync("api/v1/Product/GetProductDetails/" + "?id=" + id);
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                userProductViewModel = JsonConvert.DeserializeObject<UserProductViewModel>(Response);

            }
            return View(userProductViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}