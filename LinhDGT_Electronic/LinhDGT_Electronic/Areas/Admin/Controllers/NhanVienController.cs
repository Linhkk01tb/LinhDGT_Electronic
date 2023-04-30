using LinhDGT_Electronic.Models.EF;
using LinhDGT_Electronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI.WebControls;

namespace LinhDGT_Electronic.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: Admin/NhanVien
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Admin/NhanVien
        public ActionResult Index(int? page, string timkiem)
        {
            IEnumerable<NhanVien> items = _dbContext.NhanViens.OrderByDescending(x => x.NhanVienID);
            var pagesize = 10;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                items = items.Where(x => x.NhanVienName.Contains(timkiem));
            }
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            return View(items);
        }
        [HttpGet]
        public ActionResult ThemNhanVien()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ThemNhanVien(FormCollection f, NhanVien model)
        {

            if (ModelState.IsValid)
            {
                if (f["gender"] == "Nam")
                {
                    model.NhanVienGender = 1;
                }
                else if (f["gender"] == "Nữ")
                {
                    model.NhanVienGender = 2;
                }

                if (f["status"] == "Kích hoạt")
                    model.NhanVienStatus = 1;
                else
                    model.NhanVienStatus = 2;
                _dbContext.NhanViens.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult SuaNhanVien(int? id)
        {
            var item = _dbContext.NhanViens.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaNhanVien(FormCollection f, NhanVien model)
        {

            if (ModelState.IsValid)
            {
                if (f["gender"] == "Nam")
                {
                    model.NhanVienGender = 1;
                }
                else if (f["gender"] == "Nữ")
                {
                    model.NhanVienGender = 2;
                }
                if (f["status"] == "Kích hoạt")
                    model.NhanVienStatus = 1;
                else model.NhanVienStatus = 2;
                _dbContext.NhanViens.Attach(model);
                _dbContext.Entry(model).Property(x => x.NhanVienName).IsModified = true;
                _dbContext.Entry(model).Property(x => x.NhanVienBirth).IsModified = true;
                _dbContext.Entry(model).Property(x => x.NhanVienGender).IsModified = true;
                _dbContext.Entry(model).Property(x => x.NhanVienAddress).IsModified = true;
                _dbContext.Entry(model).Property(x => x.NhanVienEmail).IsModified = true;
                _dbContext.Entry(model).Property(x => x.NhanVienPhoneNumber).IsModified = true;
                _dbContext.Entry(model).Property(x => x.NhanVienWorkingDate).IsModified = true;
                _dbContext.Entry(model).Property(x => x.NhanVienSalary).IsModified = true;
                _dbContext.Entry(model).Property(x => x.NhanVienStatus).IsModified = true;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult XoaNhanVien(int id)
        {
            var item = _dbContext.NhanViens.Find(id);
            if (item != null)
            {
                _dbContext.NhanViens.Remove(item);
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
                        var obj = _dbContext.NhanViens.Find(Convert.ToInt32(item));
                        _dbContext.NhanViens.Remove(obj);
                        _dbContext.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}