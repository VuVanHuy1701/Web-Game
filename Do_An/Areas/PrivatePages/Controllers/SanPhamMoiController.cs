using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Do_An.Models;

namespace LayoutAdmin.Areas.PrivatePages.Controllers
{
    public class SanPhamMoiController : Controller
    {
        private static bool isupdate = false;
        // GET: PrivatePages/SanPhamMoi
        [HttpGet]
        public ActionResult Index()
        {
            List<Game> list = new DoAn_WebEntities().Games.OrderBy(x => x.TenGame).ToList<Game>();
            ViewData["game"] = list;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Game x)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            //thêm loại sp
            if (!isupdate)
                db.Games.Add(x);
            else
            {
                Game y = db.Games.Find(x.MaGame);
                y.TenGame = x.TenGame;
                y.MaCate = x.MaCate;
                y.AnhBia = x.AnhBia;
                y.GiaBan = x.GiaBan;
                y.MoTa = x.MoTa;
                y.NgayCapNhat = x.NgayCapNhat;
                y.SoLuongTon = x.SoLuongTon;
                isupdate = false;
            }
            db.SaveChanges(); // lưu vào database
            //update list to view
            if (ModelState.IsValid)
                ModelState.Clear();
            List<Game> l = db.Games.OrderBy(z => z.TenGame).ToList<Game>();
            ViewData["game"] = l;
            return View();
        }

        [HttpPost]
        public ActionResult Deletegame(string magame)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            int ma = int.Parse(magame);
            Game x = db.Games.Find(ma);
            //tìm loại sản phẩm bằng mã loại
            // tiếp theo remove mã loại đó từ danh sách
            db.Games.Remove(x);
            //Update database
            db.SaveChanges();
            List<Game> l = db.Games.OrderBy(z => z.TenGame).ToList<Game>();
            ViewData["game"] = l;
            return View("Index");
        }

        public ActionResult Updategame(string magamesua)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            int ma = int.Parse(magamesua);
            Game x = db.Games.Find(ma);
            isupdate = true;
            ViewData["game"] = db.Games.OrderBy(z => z.TenGame).ToList<Game>();
            return View("Index", x);
        }
    }
}