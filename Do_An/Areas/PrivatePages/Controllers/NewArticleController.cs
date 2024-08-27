using Do_An.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutAdmin.Areas.PrivatePages.Controllers
{
    public class NewArticleController : Controller
    {
        private static bool isupdate = false;
        // GET: PrivatePages/NewArticle
        [HttpGet]
        public ActionResult Index()
        {
            List<NewsPost> list = new DoAn_WebEntities().NewsPosts.OrderBy(x => x.PostID).ToList<NewsPost>();
            ViewData["News"] = list;
            return View();
        }
        [HttpPost]
        public ActionResult Index(NewsPost x)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            //thêm loại sp
            if (!isupdate)
                db.NewsPosts.Add(x);
            else
            {
                NewsPost y = db.NewsPosts.Find(x.PostID);
                y.PostName = x.PostName;
                y.PostImg = x.PostImg;
                y.PostDesc = x.PostDesc;
                y.dayUpdated = x.dayUpdated;
                
                y.PostNameFull = x.PostNameFull;
                isupdate = false;
            }
            db.SaveChanges(); // lưu vào database
            //update list to view
            if (ModelState.IsValid)
                ModelState.Clear();
            List<NewsPost> l = db.NewsPosts.OrderBy(z => z.PostName).ToList<NewsPost>();
            ViewData["News"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult DeletePost(string postId)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            int id = int.Parse(postId);
            NewsPost x = db.NewsPosts.Find(id);
            //tìm mã bài viết
            // tiếp theo remove mã đó từ danh sách
            db.NewsPosts.Remove(x);
            //Update database
            db.SaveChanges();
            List<NewsPost> l = db.NewsPosts.OrderBy(z => z.PostName).ToList<NewsPost>();
            ViewData["News"] = l;
            return View("Index");
        }

        public ActionResult UpdatePost(string maPost)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            int id = int.Parse(maPost);
            NewsPost x = db.NewsPosts.Find(id);
            isupdate = true;
            ViewData["News"] = db.NewsPosts.OrderBy(z => z.PostName).ToList<NewsPost>();
            return View("Index", x);
        }
    }
}