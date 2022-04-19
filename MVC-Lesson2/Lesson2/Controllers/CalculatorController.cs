using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondMVC.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student
        public ActionResult Calculate(double a = 0, double b = 0, char o = '+')
        {
            switch (o)
            {
                case '+':
                    ViewBag.KetQua = a + b;
                    break;
                case '-':
                    ViewBag.KetQua = a - b;
                    break;
                case '*':
                    ViewBag.KetQua = a * b;
                    break;
                case '/':
                    ViewBag.KetQua = a / b;
                    break;
            }
     
            return View("Index");
        }
    }
}