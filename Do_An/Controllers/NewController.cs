using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Do_An.Models;

namespace Do_An.Controllers
{
    public class NewController : Controller
    {
        // GET: New
        public ActionResult Index()
        {
            DoAn_WebEntities dBEntities = new DoAn_WebEntities();
            List<NewsPost> List = dBEntities.NewsPosts.ToList();
            return View(List);
        }
        public ActionResult DetailsPostList(int Id)
        {
            DoAn_WebEntities dBEntities = new DoAn_WebEntities();
            NewsPost post = dBEntities.NewsPosts.FirstOrDefault(x => x.PostID == Id);
            return View(post);
        }
    }
}