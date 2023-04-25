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
    public class DanhMucController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Admin/DanhMuc
        public ActionResult Index(int? page)
        {
            var pagesize = 10;
            if(page == null)
            {
                page = 1;
            }
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            var items = _dbContext.DanhMucs.OrderByDescending(x => x.DanhMucID).ToPagedList(pagenumber, pagesize);
            return View(items);
        }
        [HttpGet]
        public ActionResult ThemDanhMuc()
        {

            return View();
        }

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

        [HttpGet]
        public ActionResult SuaDanhMuc(int id) {
            var item = _dbContext.DanhMucs.Find(id);
            return View(item);
        }

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
                _dbContext.Entry(model).Property(x => x.DanhMucCode).IsModified = true;
                _dbContext.Entry(model).Property(x => x.DanhMucName).IsModified = true;
                _dbContext.Entry(model).Property(x => x.DanhMucStatus).IsModified = true;
                _dbContext.Entry(model).Property(x => x.DanhMucDescription).IsModified = true;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

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