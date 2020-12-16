using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        public ActionResult ContentResult(string name = "*") //Use a default value, for name.
        {
            name = Server.HtmlEncode(name);
            return Content(name);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string name="*") //Use a default value, for name.
        {
            if (name == "*")
            {
                //RedirectToAction("Search", "Cusisine", new { name = "french" });
                //return File(Server.MapPath("~/Content/Site.css"), "text/css");
                //return Json(new {cuisineName = name},  
            }

            //return RedirectPermanent("http://www.microsoft.com");
            return RedirectToAction("Index", "Home");
            //The content method, does not HtmlEncode.
            name = Server.HtmlEncode(name);
            return Content(name);
        }
    }
}
