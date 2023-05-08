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
    public class DonHangController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Admin/DonHang
        public ActionResult Index(int? page, string timkiem, string boloc, string sapxep)
        {

            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheongaytao = String.IsNullOrEmpty(sapxep) ? "ngaytao_desc" : "";
            IEnumerable<DonHang> items = _dbContext.DonHangs.OrderByDescending(x => x.DonHangID);
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
                case "ngaytao_desc":
                    items = items.OrderByDescending(p => p.DonHangCreatedDate);
                    break;
                default:
                    items = items.OrderBy(p => p.DonHangCreatedDate);
                    break;
            }
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                items = items.Where(x => x.DonHangCode.ToLower().Contains(timkiem));
            }
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            return View(items);
        }

        public ActionResult ChoXuLy(int? page, string timkiem, string boloc, string sapxep)
        {

            IEnumerable<DonHang> items = _dbContext.DonHangs.Where(x => x.DonHangStatus == 0).OrderByDescending(x => x.DonHangID);
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
                case "ngaytao_desc":
                    items = items.OrderByDescending(p => p.DonHangCreatedDate);
                    break;
                default:
                    items = items.OrderBy(p => p.DonHangCreatedDate);
                    break;
            }
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                items = items.Where(x => x.DonHangCode.ToLower().Contains(timkiem));
            }
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            return View(items);
        }

        public ActionResult DangGiao(int? page, string timkiem, string boloc, string sapxep)
        {

            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheongaytao = String.IsNullOrEmpty(sapxep) ? "ngaytao_desc" : "";
            IEnumerable<DonHang> items = _dbContext.DonHangs.Where(x => x.DonHangStatus == 1).OrderByDescending(x => x.DonHangID);
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
                case "ngaytao_desc":
                    items = items.OrderByDescending(p => p.DonHangCreatedDate);
                    break;
                default:
                    items = items.OrderBy(p => p.DonHangCreatedDate);
                    break;
            }
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                items = items.Where(x => x.DonHangCode.ToLower().Contains(timkiem));
            }
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            return View(items);
        }

        public ActionResult HoanThanh(int? page, string timkiem, string boloc, string sapxep)
        {

            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheongaytao = String.IsNullOrEmpty(sapxep) ? "ngaytao_desc" : "";
            IEnumerable<DonHang> items = _dbContext.DonHangs.Where(x=>x.DonHangStatus == 2).OrderByDescending(x => x.DonHangID);
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
                case "ngaytao_desc":
                    items = items.OrderByDescending(p => p.DonHangCreatedDate);
                    break;
                default:
                    items = items.OrderBy(p => p.DonHangCreatedDate);
                    break;
            }
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                items = items.Where(x => x.DonHangCode.ToLower().Contains(timkiem));
            }
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            return View(items);
        }
        public ActionResult DaHuy(int? page, string timkiem, string boloc, string sapxep)
        {

            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheongaytao = String.IsNullOrEmpty(sapxep) ? "ngaytao_desc" : "";
            IEnumerable<DonHang> items = _dbContext.DonHangs.Where(x => x.DonHangStatus == 3).OrderByDescending(x => x.DonHangID);
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
                case "ngaytao_desc":
                    items = items.OrderByDescending(p => p.DonHangCreatedDate);
                    break;
                default:
                    items = items.OrderBy(p => p.DonHangCreatedDate);
                    break;
            }
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                items = items.Where(x => x.DonHangCode.ToLower().Contains(timkiem));
            }
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            return View(items);
        }

        public ActionResult chitietdonhang(int id)
        {
            var item = _dbContext.DonHangs.Find(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult GiaoHang(int id)
        {
            var item = _dbContext.DonHangs.Find(id);
            if(item != null)
            {
               
                item.DonHangStatus = 1;
                item.DonHangModifiedDate = DateTime.Now;
                _dbContext.Entry(item).Property(x=>x.DonHangStatus).IsModified = true;
                _dbContext.Entry(item).Property(x => x.DonHangModifiedDate).IsModified = true;
                _dbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult HoanThanh(int id)
        {
            var item = _dbContext.DonHangs.Find(id);
            if (item != null)
            {
                item.DonHangStatus = 2;
                item.DonHangModifiedDate = DateTime.Now;
                _dbContext.Entry(item).Property(x => x.DonHangStatus).IsModified = true;
                _dbContext.Entry(item).Property(x => x.DonHangModifiedDate).IsModified = true;
                _dbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}