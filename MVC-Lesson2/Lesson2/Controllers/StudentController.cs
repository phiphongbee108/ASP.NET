using SecondMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student
        public ActionResult QueryString()
        {
            string Id = Request["Id"];
            string Name = Request["Name"];
            double Marks = Convert.ToDouble(Request["Marks"]);
            ViewBag.Message = Id;
            return View();
        }

        // GET: Student
        public ActionResult Form(FormCollection Fields)
        {
            string Id = Fields["Id"];
            string Name = Fields["Name"];
            double Marks = Convert.ToDouble(Fields["Marks"]);
            ViewBag.Message = Id;
            return View();
        }

        // GET: Student
        public ActionResult UseArgument(string Id, string Name, double Marks=0)
        {
            ViewBag.Message = Id;
            return View();
        }

        // GET: Student
        public ActionResult UseModel(StudentInfo model)
        {
            string Id = model.Id;
            Id = "hello";
            ViewBag.Message = Id;
            return View();
        }
    }
}