using SecondMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SecondMVC.Controllers
{
    public class MailController : Controller
    {
        // GET: SendMail
        public ActionResult Index()
        {
            return View();
        }

        // GET: SendMail
        public ActionResult Send(MailInfo model)
        {
            //Cau hinh thong tin gmail
            var mail = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(" xxx@gmail.com", "xxx"),
                EnableSsl = true
            };

            //Tao email
            var message = new MailMessage();
            message.From = new MailAddress(model.From);
            message.ReplyToList.Add(model.From);
            message.To.Add(new MailAddress(model.To));
            message.Subject = model.Subject;
            message.Body = model.Body;

            //gui mail
            mail.Send(message);

            return View("Index");
        }
    }
}