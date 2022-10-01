using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace Ecommerce_Project.Controllers
{
    public class LoginController : Controller
    {
       /* public IActionResult Index()
        {
            return View();
        }
       */
       // [HttpPost]
       /* public JsonResult Action(string username, string password)
        {
            //db Entities updateaction = new dbEntities();
            //int id = (Convert.ToInt32(Session["id"]));

            string uname = username;
            string pass = password;
            //Product pp = updateaction.Product.Where(m => m.database_id.Equals(id) && m.name.Equals(myinfo)).SingleOrDefault();
           // pp.price = price;
            //pp.product = product;
           // int i = updateaction.SaveChanges();
            //Session["warning"] = i;
            return Json(new { success = true, responseText = " Sucessfully." }, JsonRequestBehavior.AllowGet);
        }*/


    }
}
