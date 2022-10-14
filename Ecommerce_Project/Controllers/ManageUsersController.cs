using Ecommerce_Project.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce_Project.Controllers
{
    public class ManageUsersController : Controller
    {


        private readonly IWebHostEnvironment webHostEnvironment;
        public ManageUsersController(IWebHostEnvironment hostEnvironment)
        {
         
            webHostEnvironment = hostEnvironment;
        }

        HttpClient client = new HttpClient();
        string Baseurl = "https://localhost:44333";

        // GET: ManageUsersController
        public async Task<ActionResult> Index(string searchString)
        {
            List<UserResponseViewModel> userResponseViewModels = new List<UserResponseViewModel>();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
  
            var Res = await client.GetAsync("/api/User/GetRegisteredUsers");
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                userResponseViewModels = JsonConvert.DeserializeObject<List<UserResponseViewModel>>(Response);

            }
            if (!string.IsNullOrEmpty(searchString))
            {
                var searchuser = userResponseViewModels.Where(s => s.FirstName.Contains(searchString));
                return View(searchuser);
            }
            return View(userResponseViewModels);
        }

        // GET: ManageUsersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            UserResponseViewModel userResponseViewModels = new UserResponseViewModel();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
       
            HttpResponseMessage Res = await client.GetAsync("api/User/GetRegisteredUserDetails/" + "?id=" + id);
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
        public async Task<IActionResult> Create(CreateUserViewModel createUserViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    Guid id = Guid.NewGuid();
                    string imageName = id.ToString() + "_" + createUserViewModel.ImageUrl.FileName;
                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Profile", imageName);
                    

                    using (var stream = System.IO.File.Create(SavePath))
                    {
                        createUserViewModel.ImageUrl.CopyTo(stream);
                    }
                    createUserViewModel.profilepathurl = imageName;

                    MultipartFormDataContent form = new();
                    form.AddDto(createUserViewModel);
                    if (createUserViewModel.ImageUrl != null)
                    {
                        var image = createUserViewModel.ImageUrl;
                        {
                            if (image != null)
                                MultiContentExtensionMethods.AddFile(form, image, nameof(createUserViewModel.ImageUrl));
                        }
                    }
                    string url = "https://localhost:44333/api/User/CreateRegisteredUser/";
                    
                    HttpResponseMessage response = await client.PostAsync(url,form);
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
            //List<UserResponseViewModel> userResponseViewModels = new List<UserResponseViewModel>();
            // UserResponseViewModel userResponseViewModels = new UserResponseViewModel();
            UpdateUserResponseViewModel updateUserResponseViewModel = new UpdateUserResponseViewModel();
            //RegisterViewModel registerViewModel = new RegisterViewModel();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            HttpResponseMessage Res = await client.GetAsync("api/User/GetRegisteredUserDetails/" + "?id=" + id);
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                updateUserResponseViewModel = JsonConvert.DeserializeObject<UpdateUserResponseViewModel>(Response);

            }

            return View(updateUserResponseViewModel);
            
        }

        // POST: ManageUsersController/Edit/5
        // [HttpPost]
        //  [ValidateAntiForgeryToken]
        /* public ActionResult Edit(int id, IFormCollection collection)
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
        public async Task<ActionResult> Edit(long id, [FromForm] UpdateUserResponseViewModel updateUserResponseViewModel)
        {
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();

            if (updateUserResponseViewModel.ImageUrl != null)
            {
             

                    Guid uid = Guid.NewGuid();
                    string imageName = uid.ToString() + "_" + updateUserResponseViewModel.ImageUrl.FileName;
                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Profile", imageName);

                    using (var stream = System.IO.File.Create(SavePath))
                    {
                        updateUserResponseViewModel.ImageUrl.CopyTo(stream);
                    }
                    updateUserResponseViewModel.imageUrl = imageName;
               
            }

            string url = "https://localhost:44333/api/User/UpdateRegisteredUser/" + id;
            //  StringContent stringContent = new StringContent(JsonConvert.SerializeObject(updateUserResponseViewModel), Encoding.UTF8, "application/json");
            MultipartFormDataContent form = new();
            form.AddDto(updateUserResponseViewModel);
            if (updateUserResponseViewModel.ImageUrl != null)
            {
                var image = updateUserResponseViewModel.ImageUrl;
                {
                    if (image != null)
                        MultiContentExtensionMethods.AddFile(form, image, nameof(updateUserResponseViewModel.ImageUrl));
                }
            }
            HttpResponseMessage response = await client.PutAsync(url, form);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }



            // GET: ManageUsersController/Delete/5
            public async Task<ActionResult> Delete(int id)
        {

            try
            {

            
            UserViewModel userViewModel = new UserViewModel();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            HttpResponseMessage Res = await client.GetAsync("api/User/GetRegisteredUserDetails/" + "?id=" + id);
            if (Res.IsSuccessStatusCode)
            {
                 var Response = Res.Content.ReadAsStringAsync().Result;
                 userViewModel = JsonConvert.DeserializeObject<UserViewModel>(Response);
            }

                 return View(userViewModel);
            }

            catch
            {
                return View();
            }


        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, UserResponseViewModel userResponseViewModel)
        {

            try
            {

                 client.BaseAddress = new Uri(Baseurl);
                 client.DefaultRequestHeaders.Clear();
                 string url = "https://localhost:44333/api/User/DeleteRegisteredUser/" + "?id=" + id;
                 StringContent stringContent = new StringContent(JsonConvert.SerializeObject(userResponseViewModel), Encoding.UTF8, "application/json");
                 HttpResponseMessage response = await client.DeleteAsync(url);

               if (response.IsSuccessStatusCode)
               {
                  return RedirectToAction("Index");
               }

                 return View();

            }

            catch
            { 
                    return View();
            }

        }

        // POST: ManageUsersController/Delete/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        /*  public ActionResult Delete(int id, IFormCollection collection)
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
