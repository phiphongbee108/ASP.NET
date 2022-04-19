using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondMVC.Controllers
{
    public class SaveOpenController : Controller
    {
        // GET: SaveOpen
        public ActionResult Index()
        {
            string Id = Request.Form["Id"];
            ViewBag.Id = Id;
            string Name = Request.Form["Name"];
            ViewBag.Name = Name;
            string Marks = Request.Form["Marks"];
            ViewBag.Marks = Marks;
            string action = Request.Form["action"];
            String path = Server.MapPath("~/StudentInfo.txt");
            if (action == "Luu")
            {
                String[] lines = { Id, Name, Marks };
                System.IO.File.WriteAllLines(path, lines);
            } else if (action == "Mo")
            {
                String[] lines = System.IO.File.ReadAllLines(path);
                ViewBag.Id = lines[0];
                ViewBag.Name = lines[1];
                ViewBag.Marks = lines[2];
            }

            return View();
        }
    }
}