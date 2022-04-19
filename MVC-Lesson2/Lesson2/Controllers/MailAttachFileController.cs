using SecondMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace SecondMVC.Models
{
    public class MailAttachFileController : Controller
    {
        // GET: Collection
        public ActionResult Index()
        {
            return View();
        }

        // GET: Collection
        public ActionResult Send(CollectionInfo model,HttpPostedFile attach)
        {
            //Cau hinh thong tin gmail
            var mail = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("phiphongbee108@gmail.com", "Thienthu1"),
                EnableSsl = true
            };
            //Tao email
            var message = new MailMessage();
            message.From = new MailAddress(model.From);
            message.ReplyToList.Add(model.From);
            message.To.Add(new MailAddress(model.To));
            message.Subject = model.Subject;
            message.Body = model.Body;
            //attach file
            var f = Request.Files["attach"];
            if (f != null && f.ContentLength > 0)
            {
                //var path = Server.MapPath("~/FilesUpload/" + f.FileName);
                //f.SaveAs(path);
                string fileName = Path.GetFileName(f.FileName);
                message.Attachments.Add(new Attachment(f.InputStream, fileName));
                ViewBag.FileName = f.FileName;
            }
            //gui mail
            mail.Send(message);

            return View("Index");
        }
    }
}