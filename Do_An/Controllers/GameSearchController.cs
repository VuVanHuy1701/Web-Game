using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Do_An.Models;

namespace Do_An.Controllers
{
    public class GameSearchController : Controller
    {
        public ActionResult Index(int categoryId = 1)
        {
            DoAn_WebEntities dBContext = new DoAn_WebEntities();
            List<Game> ListGames = dBContext.Games
                                        .Include(cat => cat.Category)
                                        .Where(pro => pro.MaCate == categoryId).ToList();
            return View(ListGames);
        }
        public ActionResult DetailsGameList(int Id)
        {
            DoAn_WebEntities dBContext = new DoAn_WebEntities();
            Game product = dBContext.Games.Include(cat => cat.Category).FirstOrDefault(x => x.MaGame == Id);
            return View(product);
        }
        public JsonResult ListName(string q)
        {
            var data = new ProductSearch().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new ProductSearch().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.KeyWord = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
    }
}