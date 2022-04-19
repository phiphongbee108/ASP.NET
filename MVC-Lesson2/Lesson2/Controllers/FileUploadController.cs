using SecondMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondMVC.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }

        // GET: FileUpload
        public ActionResult Upload()
        {
            var f1 = Request.Files["image"];
            var f2 = Request.Files["document"];

            if (f1 != null && f1.ContentLength > 0)
            {
                var path = Server.MapPath("~/UploadFiles/" + f1.FileName);
                f1.SaveAs(path);

                ViewBag.FileName = f1.FileName;
            }

            
            if (f2 != null && f2.ContentLength > 0)
            {
                var path2 = Server.MapPath("~/UploadFiles/" + f2.FileName);
                f2.SaveAs(path2);

                ViewBag.Content = f2.FileName;
                ViewBag.FileType = f2.ContentType;
                ViewBag.FileSize = f2.ContentLength;

            }
            return View("Index");
        }
    }
}