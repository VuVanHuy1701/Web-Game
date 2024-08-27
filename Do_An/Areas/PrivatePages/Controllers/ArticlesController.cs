using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutAdmin.Areas.PrivatePages.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: PrivatePages/Articles
        public ActionResult Index()
        {
            return View();
        }
    }
}