using LinhDGT_Electronic.Models;
using LinhDGT_Electronic.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinhDGT_Electronic.Areas.Admin.Controllers
{
    public class AnhSanPhamController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Admin/AnhSanPham
        public ActionResult Index(int Id)
        {
            ViewBag.SanPhamId = Id;
            var items = _dbContext.AnhSanPhams.Where(x => x.SanPhamID == Id).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult ThemAnh(int SanPhamId, string url)
        {
                         
                _dbContext.AnhSanPhams.Add(new AnhSanPham
                {
                    SanPhamID= SanPhamId,
                    AnhName= url,
                    AnhStatus = false,
                });
                _dbContext.SaveChanges();
                return Json(new { Success = true });
         }
       
        [HttpPost]
        public ActionResult XoaAnh(int id)
        {
            var item = _dbContext.AnhSanPhams.Find(id);
            if (item != null)
            {
                _dbContext.AnhSanPhams.Remove(item);
                _dbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult XoaTatCa(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = _dbContext.AnhSanPhams.Find(Convert.ToInt32(item));
                        _dbContext.AnhSanPhams.Remove(obj);
                        _dbContext.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}