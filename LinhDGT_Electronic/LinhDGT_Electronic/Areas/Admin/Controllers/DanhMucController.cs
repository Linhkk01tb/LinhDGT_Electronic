using LinhDGT_Electronic.Models;
using LinhDGT_Electronic.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinhDGT_Electronic.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DanhMucController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Admin/DanhMuc

        /// <summary>
        /// Màn hình quản lý danh mục kết hợp tìm kiếm, phân trang, sắp xếp
        /// </summary>
        /// <param name="page"></param>
        /// <param name="timkiem"></param>
        /// <param name="boloc"></param>
        /// <param name="sapxep"></param>
        /// <returns></returns>
        public ActionResult Index(int? page, string timkiem, string boloc, string sapxep)
        {
            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheoten = String.IsNullOrEmpty(sapxep) ? "ten_desc" : "";
            IEnumerable<DanhMuc> items = _dbContext.DanhMucs.OrderByDescending(x=>x.DanhMucID);
            var pagesize = 10;
            if (timkiem != null)
            {
                page = 1;
            }
            else
            {
                timkiem = boloc;
            }
            ViewBag.boloc = boloc;
           
            switch (sapxep)
            {
                case "ten_desc":
                    items = items.OrderByDescending(p => p.DanhMucName);
                    break;
                default:
                    items = items.OrderBy(p => p.DanhMucName);
                    break;
            }
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                items = items.Where(x => x.DanhMucName.ToLower().Contains(timkiem));
            }
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            return View(items);
        }

        /// <summary>
        /// Màn hình thêm danh mục
        /// </summary>
        /// <returns></returns>
        public ActionResult ThemDanhMuc()
        {

            return View();
        }
        /// <summary>
        /// Chức năng thêm danh mục
        /// </summary>
        /// <param name="f"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ThemDanhMuc(FormCollection f, DanhMuc model)
        {

            if (ModelState.IsValid)
            {
                if (f["status"] == "Kích hoạt")
                    model.DanhMucStatus = 1;
                else 
                    model.DanhMucStatus = 2;
                _dbContext.DanhMucs.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        /// <summary>
        /// Màn hình sửa danh mục
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SuaDanhMuc(int id) {
            var item = _dbContext.DanhMucs.Find(id);
            return View(item);
        }

        /// <summary>
        /// Chức năng sửa danh mục
        /// </summary>
        /// <param name="f"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SuaDanhMuc(FormCollection f, DanhMuc model)
        {

            if (ModelState.IsValid)
            {
                if (f["status"] == "Kích hoạt")
                    model.DanhMucStatus = 1;
                else model.DanhMucStatus = 2;
                _dbContext.DanhMucs.Attach(model);
                _dbContext.Entry(model).Property(x => x.DanhMucName).IsModified = true;
                _dbContext.Entry(model).Property(x => x.DanhMucStatus).IsModified = true;
                _dbContext.Entry(model).Property(x => x.DanhMucDescription).IsModified = true;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        /// <summary>
        /// Chức năng xoá danh mục
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult XoaDanhMuc(int id)
        {
            var item = _dbContext.DanhMucs.Find(id);
            if (item != null)
            {
                _dbContext.DanhMucs.Remove(item);
                _dbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false});
        }
    }
}