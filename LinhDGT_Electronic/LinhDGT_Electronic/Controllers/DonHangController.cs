using LinhDGT_Electronic.Models;
using LinhDGT_Electronic.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinhDGT_Electronic.Controllers
{
    public class DonHangController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: DonHang
        public ActionResult Index(string id,int? page, string timkiem, string boloc, string sapxep)
        {

            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheongaytao = String.IsNullOrEmpty(sapxep) ? "ngaytao_desc" : "";
            IEnumerable<DonHang> items = _dbContext.DonHangs.Where(x=>x.UserId == id).OrderByDescending(x => x.DonHangID);
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

        public ActionResult ChoXuLy(string id,int? page, string timkiem, string boloc, string sapxep)
        {

            IEnumerable<DonHang> items = _dbContext.DonHangs.Where(x=> x.UserId == id).Where(x=>x.DonHangStatus == 0).OrderByDescending(x => x.DonHangID);
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

        public ActionResult DangGiao(string id, int? page, string timkiem, string boloc, string sapxep)
        {

            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheongaytao = String.IsNullOrEmpty(sapxep) ? "ngaytao_desc" : "";
            IEnumerable<DonHang> items = _dbContext.DonHangs.Where(x => x.UserId == id).Where(x => x.DonHangStatus == 1).OrderByDescending(x => x.DonHangID);
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

        public ActionResult HoanThanh(string id, int? page, string timkiem, string boloc, string sapxep)
        {

            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheongaytao = String.IsNullOrEmpty(sapxep) ? "ngaytao_desc" : "";
            IEnumerable<DonHang> items = _dbContext.DonHangs.Where(x => x.UserId == id).Where(x => x.DonHangStatus == 2).OrderByDescending(x => x.DonHangID);
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
        public ActionResult DaHuy(string id, int? page, string timkiem, string boloc, string sapxep)
        {

            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheongaytao = String.IsNullOrEmpty(sapxep) ? "ngaytao_desc" : "";
            IEnumerable<DonHang> items = _dbContext.DonHangs.Where(x => x.UserId == id).Where(x => x.DonHangStatus == 3).OrderByDescending(x => x.DonHangID);
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
        public ActionResult HuyDon(int id)
        {
            var item = _dbContext.DonHangs.Find(id);
            if (item != null)
            {
                foreach(var item1 in _dbContext.ChiTietDonHangs)
                {
                    foreach(var item2 in _dbContext.SanPhams)
                    {
                        if(item1.SanPhamID == item2.SanPhamID)
                        {
                            item2.SanPhamSellQuantity -= item1.SoLuongMua;
                            item2.SanPhamQuantity += item1.SoLuongMua;
                            _dbContext.Entry(item2).Property(x => x.SanPhamQuantity).IsModified = true;
                            _dbContext.Entry(item2).Property(x => x.SanPhamSellQuantity).IsModified = true;
                        }
                    }
                }
                item.DonHangStatus = 3;
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