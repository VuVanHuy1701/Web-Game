using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An.Models
{
    public class ProductSearch
    {
        DoAn_WebEntities db = null;
        public ProductSearch()
        {
            this.db = new DoAn_WebEntities();
        }
        public List<string> ListName(string keyword)
        {
            return db.Games.Where(x => x.TenGame.Contains(keyword)).Select(x => x.TenGame).ToList();
        }
        public List<Game_Category> Search(string keyword, ref int totalRecord, int pageIndex, int pageSize = 1)
        {
            totalRecord = db.Games.Where(x => x.TenGame.Contains(keyword)).Count();
            var model = (from a in db.Games
                         join b in db.Game_Category
                         on a.MaCate equals b.MaGame
                         where a.TenGame.Contains(keyword)
                         select new
                         {
                             CatName = b.TenHangMuc,
                             ProName = a.TenGame,
                             ProId = a.MaGame,
                             ProImage = a.AnhBia,
                             ProPrice = a.GiaBan,
                         }).AsEnumerable().Select(x => new Game_Category()
                         {
                             TenHangMuc = x.CatName,
                             TenGame = x.ProName,
                             MaGame = x.ProId,
                             AnhBia = x.ProImage,
                             GiaBan = x.ProPrice
                         });
            model.OrderByDescending(x => x.MaGame).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}