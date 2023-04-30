using LinhDGT_Electronic.Models.EF;
using LinhDGT_Electronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Helpers;

namespace LinhDGT_Electronic.Areas.Admin.Controllers
{
    public class ThuongHieuController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Admin/ThuongHieu
        public ActionResult Index(int? page)
        {
            var pagesize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            var items = _dbContext.ThuongHieus.OrderByDescending(x => x.ThuongHieuID).ToPagedList(pagenumber, pagesize);
            return View(items);
        }
        [HttpGet]
        public ActionResult ThemThuongHieu()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ThemThuongHieu(FormCollection f, ThuongHieu model)
        {

            if (ModelState.IsValid)
            {
                if (f["status"] == "Kích hoạt")
                    model.ThuongHieuStatus = 1;
                else
                    model.ThuongHieuStatus = 2;
                _dbContext.ThuongHieus.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult SuaThuongHieu(int id)
        {
            var item = _dbContext.ThuongHieus.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SuaThuongHieu(FormCollection f, ThuongHieu model)
        {

            if (ModelState.IsValid)
            {
                if (f["status"] == "Kích hoạt")
                    model.ThuongHieuStatus = 1;
                else model.ThuongHieuStatus = 2;
                _dbContext.ThuongHieus.Attach(model);
                _dbContext.Entry(model).Property(x => x.ThuongHieuName).IsModified = true;
                _dbContext.Entry(model).Property(x => x.ThuongHieuStatus).IsModified = true;
                _dbContext.Entry(model).Property(x => x.ThuongHieuDescription).IsModified = true;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult XoaThuongHieu(int id)
        {
            var item = _dbContext.ThuongHieus.Find(id);
            if (item != null)
            {
                _dbContext.ThuongHieus.Remove(item);
                _dbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}