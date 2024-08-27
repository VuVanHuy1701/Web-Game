using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using Do_An.Models;

namespace Do_An.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        private static bool isupdate = false;
        // GET: PrivatePages/NewArticle
        [HttpGet]
        public ActionResult Index()
        {
            List<KhachHang> list = new DoAn_WebEntities().KhachHangs.OrderBy(x => x.MaKH).ToList<KhachHang>();
            ViewData["KH"] = list;
            return View();
        }
        [HttpPost]
        public ActionResult Index(KhachHang x)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            //thêm loại sp
            if (!isupdate)
                db.KhachHangs.Add(x);
            else
            {
                KhachHang y = db.KhachHangs.Find(x.MaKH);
                y.HoTen = x.HoTen;
                y.Email = x.Email;
                y.TaiKhoan = x.TaiKhoan;
                y.DiachiKH = x.DiachiKH;
                y.NgaySinh = x.NgaySinh;
                isupdate = false;
            }
            db.SaveChanges(); // lưu vào database
            //update list to view
            if (ModelState.IsValid)
                ModelState.Clear();
            List<KhachHang> l = db.KhachHangs.OrderBy(z => z.HoTen).ToList<KhachHang>();
            ViewData["KH"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult DeletePost(string khid)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            int id = int.Parse(khid);
            KhachHang x = db.KhachHangs.Find(id);
            //tìm loại sản phẩm bằng mã loại
            // tiếp theo remove mã loại đó từ danh sách
            db.KhachHangs.Remove(x);
            //Update database
            db.SaveChanges();
            List<KhachHang> l = db.KhachHangs.OrderBy(z => z.HoTen).ToList<KhachHang>();
            ViewData["KH"] = l;
            return View("Index");
        }

        public ActionResult UpdatePost(string makh)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            int id = int.Parse(makh);
            KhachHang x = db.KhachHangs.Find(id);
            isupdate = true;
            ViewData["KH"] = db.KhachHangs.OrderBy(z => z.HoTen).ToList<KhachHang>();
            return View("Index", x);
        }
    }


}
