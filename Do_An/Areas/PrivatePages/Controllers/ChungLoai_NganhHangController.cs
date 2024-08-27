using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Do_An.Models;

namespace LayoutAdmin.Areas.PrivatePages.Controllers
{
    public class ChungLoai_NganhHangController : Controller
    {
        private static bool isupdate = false;
        // GET: PrivatePages/ChungLoai_NganhHang
        [HttpGet]
        public ActionResult Index()
        {
            List<Category> list = new DoAn_WebEntities().Categories.OrderBy(x => x.TenHangMuc).ToList<Category>();
            ViewData["theloai"] = list;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Category x)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            //thêm loại sp
            if (!isupdate)
                db.Categories.Add(x);
            else
            {
                Category y = db.Categories.Find(x.MaCategory);
                y.TenHangMuc = x.TenHangMuc;
                y.ghichu = x.ghichu;
                isupdate = false;
            }
            db.SaveChanges(); // lưu vào database
            //update list to view
            if (ModelState.IsValid)
                ModelState.Clear();
            List<Category> l = db.Categories.OrderBy(z => z.TenHangMuc).ToList<Category>();
            ViewData["theloai"] = l;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(string macate) 
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            int ma = int.Parse(macate);
            Category x = db.Categories.Find(ma);
            //tìm loại sản phẩm bằng mã loại
            // tiếp theo remove mã loại đó từ danh sách
            db.Categories.Remove(x);
            //Update database
            db.SaveChanges();
            List<Category> l = db.Categories.OrderBy(z => z.TenHangMuc).ToList<Category>();
            ViewData["theloai"] = l;
            return View("Index");
        }
        
        public ActionResult Update(string masua)
        {
            DoAn_WebEntities db = new DoAn_WebEntities();
            int ma = int.Parse(masua);
            Category x = db.Categories.Find(ma);
            isupdate = true;
            ViewData["theloai"] = db.Categories.OrderBy(z => z.TenHangMuc).ToList<Category>();
            return View("Index", x);
        }
    }
}