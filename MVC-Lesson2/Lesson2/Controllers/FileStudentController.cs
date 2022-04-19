using SecondMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace SecondMVC.Controllers
{
    public class FileStudentController : Controller
    {
        // GET: FileInfo
        public ActionResult Index(FileStudentInfo model)
        {
            //ID
            string Id = Request.Form["Id"];
            ViewBag.Id = Id;
            //Ho ten
            string Name = Request.Form["Name"];
            ViewBag.Name = Name;
            //Gioi tinh
            string Sex = Request.Form["Sex"];
            ViewBag.Sex = Sex;
            //Ngay sinh
            string Date = Request.Form["Date"];
            ViewBag.Date = Date;
            //hoc phi
            string Fee = Request.Form["Fee"];
            ViewBag.Fee = Fee;
            //Anh
            var f = Request.Files["image"];

            if (f != null && f.ContentLength > 0)
            {
                var path2 = Server.MapPath("~/Content/UploadFiles/" + f.FileName);
                f.SaveAs(path2);
                ViewBag.FileName = f.FileName;
            }
            //Ghi chu
            string Note = Request.Form["Note"];
            ViewBag.Note = Note;
            //Get action
            string action = Request.Form["action"];

            String path = Server.MapPath("~/FileStudentInfo.txt");
            if (action == "Save")
            {
                String[] lines = { Id, Name, Sex, Date, Fee, Note };
                System.IO.File.WriteAllLines(path, lines);
            }
            else if (action == "Open")
            {
                String[] lines = System.IO.File.ReadAllLines(path);
                ViewBag.Id = lines[0];
                ViewBag.Name = lines[1];
                ViewBag.Sex = lines[2];
                ViewBag.Date = lines[3];
                ViewBag.Fee = lines[4];
                ViewBag.Note = lines[5];
            }
            return View();
        }
    }
}