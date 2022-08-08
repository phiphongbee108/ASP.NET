using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using OnlineShop.Models.Dao;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login        
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password), true);
                if (result == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    userSession.GroupID = user.GroupID;
                    var listCredentials = dao.GetListCredential(model.UserName);
                    Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Username does not exist!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Account is locked or disabled!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Wrong Password!");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Account does not have permission to access!");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password!");
                }
            }
            return View();
        }
    }
}