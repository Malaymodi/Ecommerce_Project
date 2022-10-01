using Ecommerce_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;


namespace Ecommerce_Project.Controllers
{
    public class ProductController : Controller
    {
        
        HttpClient client = new HttpClient();
        string Baseurl = "https://localhost:44333";

        // GET: ProductController
       /* public async Task<ActionResult> Index()
        {
            List < Products > products = new List<Products>();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            string url = "api/Product";
            HttpResponseMessage Res = await client.GetAsync("api/Product");
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Products>>(Response);
            }
            return View(products);
        }
        */

        public async Task<ActionResult> Index2(Products product)
        
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



             return View("index",products);
            //return RedirectToAction("index", "Home",products);
        }
        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Products product = new Products();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            string url = "api/Product";
            HttpResponseMessage Res = await client.GetAsync("api/v1/Product/GetProductDetails/" + "?id=" + id);
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Products>(Response);
            }



            // return View("index","Home",products);
          
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        public async Task<ActionResult> Create(ProductViewModel productViewModel)
        {
           // List<Products> createproducts = new List<Products>();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            string url = "api/Product";
            HttpResponseMessage response = await client.PostAsJsonAsync("api/v1/Product/CreateProduct/", productViewModel);

            return View(productViewModel);
        }
      

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
