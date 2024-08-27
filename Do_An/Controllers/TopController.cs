using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Do_An.Models;

namespace Do_An.Controllers
{
    public class TopController : Controller
    {
        // GET: Product
        public ActionResult Index(int cateId = 1)
        {
            DoAn_WebEntities dBEntities = new DoAn_WebEntities();
            List<Game> List = dBEntities.Games
                                .Include(cart => cart.Category)
                                .Where(pro => pro.MaCate == cateId).ToList();
            return View(List);
        }

        public ActionResult Details(int id)
        {
            DoAn_WebEntities dBEntities = new DoAn_WebEntities();
            Game product = dBEntities.Games.Include(cart => cart.Category).FirstOrDefault(x => x.MaGame == id);

            return View(product);
        }
    }
}