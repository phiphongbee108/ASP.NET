using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;


namespace SecondMVC.Controllers
{
    public class OutputController : Controller
    {
        // GET: ActionResult
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WithLayout()
        {
            return View("Index");
        }

        public ActionResult WithoutLayout()
        {
            return PartialView("Index");
        }

        public ActionResult TextPlain()
        {
            return Content("Welcome to ASP.NET MVC5");
        }

        public ActionResult FileContent()
        {
            return File("~/Global.asax.cs", "text/plain");
        }

        public ActionResult RedirectToAction()
        {
            return RedirectToAction("About", "Home");
        }

        public ActionResult RedirectToUrl()
        {
            return Redirect("http://gmail.com");
        }

        public ActionResult JsonObject()
        {
            var data = new { Name = "ABC", Year = 2000 };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JsonArray()
        {
            ArrayList data = new ArrayList();
            //or
            //var data = new ArrayList();
            data.Add(new { Name = "GHI", Year = 1996 });
            data.Add(new { Name = "DEF", Year = 2001 });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}