using LinhDGT_Electronic.Models.EF;
using LinhDGT_Electronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace LinhDGT_Electronic.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Admin/SanPham
        public ActionResult Index(int? page, string timkiem)
        {
            IEnumerable<SanPham> items = _dbContext.SanPhams.OrderByDescending(x => x.SanPhamID);
            var pagesize = 10;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                items = items.Where(x => x.SanPhamName.Contains(timkiem));
            }
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            return View(items);
        }
        [HttpGet]
        public ActionResult ThemSanPham()
        {
            ViewBag.DanhMucID = new SelectList(_dbContext.DanhMucs, "DanhMucID", "DanhMucName");
            ViewBag.ThuongHieuID = new SelectList(_dbContext.ThuongHieus, "ThuongHieuID", "ThuongHieuName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ThemSanPham(FormCollection frm, SanPham model, List<string> Images)
        {

            if (ModelState.IsValid)
            {
                model.SanPhamImage = "";
                var f = Request.Files["SanPhamImage"];
                if (f != null && f.ContentLength > 0)
                {
                    string filename = System.IO.Path.GetFileName(f.FileName);
                    string upath = Server.MapPath("~/Content/assets/images/" + filename);
                    f.SaveAs(upath);
                    model.SanPhamImage = filename;
                }
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        
                           
                            model.AnhSanPhams.Add(new AnhSanPham
                            {
                                SanPhamID = model.SanPhamID,
                                AnhName = Images[i],
                                AnhStatus = true,
                            });
    
                    }
                }
                if (frm["status"] == "Kích hoạt")
                    model.SanPhamStatus = 1;
                else
                    model.SanPhamStatus = 2;
                _dbContext.SanPhams.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DanhMucID = new SelectList(_dbContext.DanhMucs, "DanhMucID", "DanhMucName", model.DanhMucID);
            ViewBag.ThuongHieuID = new SelectList(_dbContext.ThuongHieus, "ThuongHieuID", "ThuongHieuName", model.ThuongHieuID);
            return View(model);
        }

        [HttpGet]
        public ActionResult SuaSanPham(int? id)
        {
            ViewBag.DanhMucID = new SelectList(_dbContext.DanhMucs, "DanhMucID", "DanhMucName");
            ViewBag.ThuongHieuID = new SelectList(_dbContext.ThuongHieus, "ThuongHieuID", "ThuongHieuName");
            var item = _dbContext.SanPhams.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SuaSanPham(FormCollection frm, SanPham model)
        {

            if (ModelState.IsValid)
            {
                model.SanPhamImage = "";
                var f = Request.Files["SanPhamImage"];
                if (f != null && f.ContentLength > 0)
                {
                    string filename = System.IO.Path.GetFileName(f.FileName);
                    string upath = Server.MapPath("~/Content/assets/images/" + filename);
                    f.SaveAs(upath);
                    model.SanPhamImage = filename;
                }
                if (frm["status"] == "Kích hoạt")
                    model.SanPhamStatus = 1;
                else model.SanPhamStatus = 2;
                _dbContext.SanPhams.Attach(model);
                _dbContext.Entry(model).Property(x => x.SanPhamName).IsModified = true;
                _dbContext.Entry(model).Property(x => x.SanPhamImage).IsModified = true;
                _dbContext.Entry(model).Property(x => x.SanPhamProducedYear).IsModified = true;
                _dbContext.Entry(model).Property(x => x.DanhMucID).IsModified = true;
                _dbContext.Entry(model).Property(x => x.ThuongHieuID).IsModified = true;
                _dbContext.Entry(model).Property(x => x.SanPhamQuantity).IsModified = true;
                _dbContext.Entry(model).Property(x => x.SanPhamUnitPrice).IsModified = true;
                _dbContext.Entry(model).Property(x => x.SanPhamStatus).IsModified = true;
                _dbContext.Entry(model).Property(x => x.SanPhamDescription).IsModified = true;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DanhMucID = new SelectList(_dbContext.DanhMucs, "DanhMucID", "DanhMucName", model.DanhMucID);
            ViewBag.ThuongHieuID = new SelectList(_dbContext.ThuongHieus, "ThuongHieuID", "ThuongHieuName", model.ThuongHieuID);
            return View(model);
        }

        [HttpPost]
        public ActionResult XoaSanPham(int id)
        {
            var item = _dbContext.SanPhams.Find(id);
            if (item != null)
            {
                _dbContext.SanPhams.Remove(item);
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
                        var obj = _dbContext.SanPhams.Find(Convert.ToInt32(item));
                        _dbContext.SanPhams.Remove(obj);
                        _dbContext.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}