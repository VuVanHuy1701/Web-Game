using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Do_An.Controllers
{
    public class LoginAdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string acc, string pass)
        {
            bool isAuthentic = (acc != null && pass != null && acc.ToLower().Equals("admin") && pass.Equals("admin"));
            if (isAuthentic)
                return RedirectToAction("Index", "Dashboard", new { Area = "PrivatePages"});
            //nếu chứng thực ko thành công thì vẫn nạp view lên cho nhập mật khẩu lại
            return View();
        }
    }
}