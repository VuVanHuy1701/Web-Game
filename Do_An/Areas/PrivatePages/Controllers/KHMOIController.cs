using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An.Models;

namespace LayoutAdmin.Areas.PrivatePages.Controllers
{
    public class KHMOIController : Controller
    {
        // GET: PrivatePages/KHMOI
        [HttpGet]
        public ActionResult Index()
        {
            List<KhachHang> list = new DoAn_WebEntities().KhachHangs.OrderBy(x => x.HoTen).ToList<KhachHang>();
            ViewData["KH"] = list;
            return View();
        }
        [HttpPost]
        public ActionResult Index(KhachHang x)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            KhachHang y = db.KhachHangs.Find(x.MaKH);
            y.HoTen = x.HoTen;
            y.TaiKhoan = x.TaiKhoan;
            y.Email = x.Email;
            y.DiachiKH = x.DiachiKH;
            y.NgaySinh = x.NgaySinh;
            

            db.SaveChanges(); // lưu vào database
            //update list to view
            if (ModelState.IsValid)
                ModelState.Clear();
            List<KhachHang> l = db.KhachHangs.OrderBy(z => z.HoTen).ToList<KhachHang>();
            ViewData["KH"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult DeleteKH(string maKH)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            int ma = int.Parse(maKH);
            KhachHang x = db.KhachHangs.Find(ma);
           
            db.KhachHangs.Remove(x);
            //Update database
            db.SaveChanges();
            List<KhachHang> l = db.KhachHangs.OrderBy(z => z.HoTen).ToList<KhachHang>();
            ViewData["KH"] = l;
            return View("Index");
        }
    }
}