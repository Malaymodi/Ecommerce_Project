using Ecommerce_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.Collections;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project.Controllers
{
    public class ProductController : Controller
    {
        
        HttpClient client = new HttpClient();
        string Baseurl = "https://localhost:44333";

        // GET: ProductController
        
        public async Task<ActionResult> Index()
        {
            List<ProductResponseViewModel> products = new List<ProductResponseViewModel>();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            string url = "api/Product";
            var Res = await client.GetAsync("/api/v1/Product/GetProducts");
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductResponseViewModel>>(Response);

            }
            return View(products);
        }

     
       
        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ProductResponseViewModel productResponseViewModel = new ProductResponseViewModel();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            string url = "api/Product";
            HttpResponseMessage Res = await client.GetAsync("api/v1/Product/GetProductDetails/" + "?id=" + id);
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                productResponseViewModel = JsonConvert.DeserializeObject<ProductResponseViewModel>(Response);

            }
            return View(productResponseViewModel);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        // [HttpPost]
        //[ValidateAntiForgeryToken]
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
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            // List<Products> createproducts = new List<Products>();
             if (ModelState.IsValid)
             {
                 try
                 {

                     client.BaseAddress = new Uri(Baseurl);
                     client.DefaultRequestHeaders.Clear();
                  //  List<ProductImagesRequestModel> images = new List<ProductImagesRequestModel>();
                    foreach (IFormFile imageFile in productViewModel.ProductImages)
                    {

                        Guid id = Guid.NewGuid();
                        // string imageName = id.ToString() + "_" + imageFile.FileName;
                        string imageName = imageFile.FileName;
                        string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageName);

                        using (var stream = System.IO.File.Create(SavePath))
                        {
                            imageFile.CopyTo(stream);
                        }
                     /*   var img = new ProductImagesRequestModel
                        {
                            imageUrl = imageName,
                            ImageName = imageFile.FileName,
                        };
                     */
                    }
                    

                        MultipartFormDataContent form = new();
                    form.AddDto(productViewModel);
                    if (productViewModel.ProductImages != null)
                    {
                        foreach (var image in productViewModel.ProductImages)
                        {
                            if (image != null)
                                MultiContentExtensionMethods.AddFile(form, image, nameof(productViewModel.ProductImages));
                        }
                    }
                    string url = "https://localhost:44333/api/v1/Product/CreateProduct/";
                   //  StringContent stringContent = new StringContent(JsonConvert.SerializeObject(productViewModel), Encoding.UTF8, "application/json");
                     HttpResponseMessage response = await client.PostAsync(url, form);
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
      
        

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            // ProductViewModel productViewModel = new ProductViewModel();
            //ProductResponseViewModel prvm = new ProductResponseViewModel();
            List<ProductResponseViewModel> prvm = new List<ProductResponseViewModel>();

            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            string url = "api/Product";

            HttpResponseMessage Res = await client.GetAsync("api/v1/Product/GetProductDetails/" + "?id=" + id);
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                prvm = JsonConvert.DeserializeObject<List<ProductResponseViewModel>>(Response);
            }

            return View(prvm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, ProductViewModel productViewModel)
        {
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            MultipartFormDataContent form = new();
            form.AddDto(productViewModel);
            if (productViewModel.ProductImages != null)
            {
                foreach (var image in productViewModel.ProductImages)
                {
                    if (image != null)
                        MultiContentExtensionMethods.AddFile(form, image, nameof(productViewModel.ProductImages));
                }
            }
            string url = "https://localhost:44333/api/v1/Product/" + "?id=" + id;
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(productViewModel), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // POST: ProductController/Edit/5
        /*  [HttpPost]
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
          }*/

        // GET: ProductController/Delete/5
      
        public async Task<IActionResult> Delete(int id)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            string url = "api/Product";

            HttpResponseMessage Res = await client.GetAsync("api/v1/Product/GetProductDetails/" + "?id=" + id);
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                productViewModel = JsonConvert.DeserializeObject<ProductViewModel>(Response);
            }

            return View(productViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, ProductViewModel productViewModel)
        {
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            string url = "https://localhost:44333/api/v1/Product/DeleteProduct/" + "?id=" + id;
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(productViewModel), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
            // POST: ProductController/Delete/5
            /*[HttpPost]
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
            }*/
        }

    public static class MultiContentExtensionMethods
    {
        public static void AddDto<TDto>(this MultipartFormDataContent multiContent, TDto dto)
        {
            List<PropertyInfo> propertyInfos = dto.GetType().GetProperties().ToList();

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.PropertyType != typeof(IFormFile) &&
                   !propertyInfo.PropertyType.Name.Contains("List"))
                {
                    if (propertyInfo.GetValue(dto) is not null)
                        multiContent.Add(new StringContent(propertyInfo.GetValue(dto).ToString()), propertyInfo.Name);
                }
                else if (propertyInfo.PropertyType != typeof(IFormFile) &&
                    propertyInfo.PropertyType.Name.Contains("List"))
                {
                    var list = (IList)propertyInfo.GetValue(dto, null);

                    if (list is not null)
                        foreach (var item in list)
                        {
                            if (item != null)
                                multiContent.Add(new StringContent(item.ToString()), propertyInfo.Name);
                        }
                }
            }
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
