using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

using Do_An.Models;

namespace Do_An.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            using (DoAn_WebEntities context = new DoAn_WebEntities())
            {
                model.UserPassword = GetMD5(model.UserPassword);
                bool IsValidUser = context.Admins.Any(user => user.UserAdmin.ToLower() ==
                        model.UserName.ToLower() && user.PassAdmin == model.UserPassword);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Signup(Admin model)
        {
            using (DoAn_WebEntities context = new DoAn_WebEntities())
            {
                model.PassAdmin = GetMD5(model.PassAdmin);
                context.Admins.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
    }
}