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
    [Authorize(Roles = "Admin")]
    public class ThuongHieuController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Admin/ThuongHieu
        public ActionResult Index(int? page, string timkiem, string boloc, string sapxep)
        {
            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheoten = String.IsNullOrEmpty(sapxep) ? "ten_desc" : "";
            IEnumerable<ThuongHieu> items = _dbContext.ThuongHieus.OrderByDescending(x => x.ThuongHieuID);
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
                    items = items.OrderByDescending(p => p.ThuongHieuName);
                    break;
                default:
                    items = items.OrderBy(p => p.ThuongHieuName);
                    break;
            }
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                items = items.Where(x => x.ThuongHieuName.ToLower().Contains(timkiem));
            }
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
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