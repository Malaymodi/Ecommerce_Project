using Ecommerce_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce_Project.Controllers
{
    public class ManageUsersController : Controller
    {
        HttpClient client = new HttpClient();
        string Baseurl = "https://localhost:44333";

        // GET: ManageUsersController
        public async Task<ActionResult> Index()
        {
            List<UserResponseViewModel> userResponseViewModels = new List<UserResponseViewModel>();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
  
            var Res = await client.GetAsync("/api/Account/GetRegisteredUsers");
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                userResponseViewModels = JsonConvert.DeserializeObject<List<UserResponseViewModel>>(Response);

            }
            return View(userResponseViewModels);
        }

        // GET: ManageUsersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            UserResponseViewModel userResponseViewModels = new UserResponseViewModel();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
       
            HttpResponseMessage Res = await client.GetAsync("api/Account/GetRegisteredUserDetails/" + "?id=" + id);
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                userResponseViewModels = JsonConvert.DeserializeObject<UserResponseViewModel>(Response);

            }
            return View(userResponseViewModels);
        }

        // GET: ManageUsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageUsersController/Create
       // [HttpPost]
        // [ValidateAntiForgeryToken]
        /* public ActionResult Create(IFormCollection collection)
         {
             try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {
                 return View();
             }
         }*/

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();    
                    string url = "https://localhost:44333/api/Account/CreateRegisteredUser/";
                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(userViewModel), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");

                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View();
        }

        // GET: ManageUsersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            List<UserResponseViewModel> userResponseViewModels = new List<UserResponseViewModel>();

            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            HttpResponseMessage Res = await client.GetAsync("api/Account/GetRegisteredUserDetails/" + "?id=" + id);
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                userResponseViewModels = JsonConvert.DeserializeObject<List<UserResponseViewModel>>(Response);
            }

            return View(userResponseViewModels);
            
        }

        // POST: ManageUsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageUsersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            UserViewModel userViewModel = new UserViewModel();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            HttpResponseMessage Res = await client.GetAsync("api/Account/GetRegisteredUserDetails/" + "?id=" + id);
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                userViewModel = JsonConvert.DeserializeObject<UserViewModel>(Response);
            }

            return View(userViewModel);
        }

        // POST: ManageUsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
