using LinhDGT_Electronic.Models;
using LinhDGT_Electronic.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinhDGT_Electronic.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AnhSanPhamController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Admin/AnhSanPham

        /// <summary>
        /// Màn hình quản lý hình ảnh của sản phẩm
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Index(int Id)
        {
            ViewBag.SanPhamId = Id;
            var items = _dbContext.AnhSanPhams.Where(x => x.SanPhamID == Id).ToList();
            return View(items);
        }
        /// <summary>
        /// Chức năng thêm ảnh
        /// </summary>
        /// <param name="SanPhamId"></param>
        /// <param name="url"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Chức năng xoá ảnh
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Chức năng xoá nhiều ảnh được chọn
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
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