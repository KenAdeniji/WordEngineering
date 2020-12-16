using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ActionResultsController : Controller
    {
        public ActionResult ContentResult(string name = "*") //Use a default value, for name.
        {
            name = Server.HtmlEncode(name);
            return Content(name);
        }

        public ActionResult FilePathResult()
        {
            return File(Server.MapPath("~/Content/Site.css"), "text/css");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RedirectPermanentResult()
        {
            return RedirectPermanent("http://www.microsoft.com");
        }

        public ActionResult RedirectToActionResult()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
