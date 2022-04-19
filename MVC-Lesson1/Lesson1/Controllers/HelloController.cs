using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }

        //
        //GET: Hello/SayHello
        public ActionResult SayHello()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC5";
            return View();
        }
    }
}