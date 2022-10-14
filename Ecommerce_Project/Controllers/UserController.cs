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

        public async Task<IActionResult> Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel user)
        {
            using(var httpclient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync("https://localhost:44333/api/User/authenticate", stringContent))
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

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();


            string imageName = registerViewModel.ImageUrl.FileName;
            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Profile", imageName);

            using (var stream = System.IO.File.Create(SavePath))
            {
                registerViewModel.ImageUrl.CopyTo(stream);
            }

            MultipartFormDataContent form = new();
            form.AddDto(registerViewModel);
            if (registerViewModel.ImageUrl != null)
            {
                var image = registerViewModel.ImageUrl;
                {
                    if (image != null)
                        MultiContentExtensionMethods.AddFile(form, image, nameof(registerViewModel.ImageUrl));
                }
            }
            string url = "https://localhost:44333/api/User/CreateRegisteredUser";

            HttpResponseMessage response = await client.PostAsync(url, form);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");

            }
            return View();
        }
        public static void AddFile(MultipartFormDataContent multiContent, IFormFile file, string name)
        {
            byte[] data;
            using (var br = new BinaryReader(file.OpenReadStream()))
            {
                data = br.ReadBytes((int)file.OpenReadStream().Length);
            }

            ByteArrayContent bytes = new(data);

            multiContent.Add(bytes, name, file.FileName);
        }
    }
}
