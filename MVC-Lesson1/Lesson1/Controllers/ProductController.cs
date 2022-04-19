using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Search()
        {
            ViewBag.Message = "Search";
            return View();
        }

        // GET: Product
        public ActionResult HelloWorld()
        {
            ViewBag.Message = "Hello World";
            return View();
        }

        // GET: Product
        public ActionResult Hello()
        {
            ViewBag.Message = "Hello";
            return View();
        }

        // GET: Product
        public ActionResult World()
        {
            ViewBag.Message = "World";
            return View();
        }
    }
}