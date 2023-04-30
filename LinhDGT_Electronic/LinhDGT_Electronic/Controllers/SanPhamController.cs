using LinhDGT_Electronic.Models;
using LinhDGT_Electronic.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinhDGT_Electronic.Controllers
{
    public class SanPhamController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SanPhamTheoDanhMuc(int danhmucid, int? page)
        {
            IEnumerable<SanPham> items = _dbContext.SanPhams.Where(x => x.DanhMucID == danhmucid && x.SanPhamStatus == 1).OrderByDescending(x => x.SanPhamID);
            var pagesize = 10;
            if (page == null)
            {
                page = 1;
            }
            //ViewBag.item = @String.Format("{ 0:0,0 vnđ}", 200000);
            ViewBag.name = _dbContext.DanhMucs.Where(x => x.DanhMucID == danhmucid).FirstOrDefault().DanhMucName;
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            return PartialView(items);
        }
        public ActionResult SanPhamTheoThuongHieu(int thuonghieuid, int? page)
        {
            IEnumerable<SanPham> items = _dbContext.SanPhams.Where(x => x.ThuongHieuID == thuonghieuid && x.SanPhamStatus == 1).OrderByDescending(x => x.SanPhamID);
            var pagesize = 10;
            if (page == null)
            {
                page = 1;
            }
            //ViewBag.item = @String.Format("{ 0:0,0 vnđ}", 200000);
            ViewBag.name = _dbContext.ThuongHieus.Where(x => x.ThuongHieuID == thuonghieuid).FirstOrDefault().ThuongHieuName;
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            return PartialView(items);
        }
        public ActionResult ChiTietSanPham(int sanphamid)
        {
            var item = _dbContext.SanPhams.Where(x => x.SanPhamID == sanphamid).FirstOrDefault(x => x.SanPhamStatus == 1);
            return PartialView(item);
        }
        public ActionResult ChiTietSanPhamTheoDanhMuc(int danhmucid, int sanphamid)
        {
            ViewBag.danhmuc = _dbContext.DanhMucs.FirstOrDefault(x => x.DanhMucID == danhmucid).DanhMucName;
            var item = _dbContext.SanPhams.Where(x => x.SanPhamID == sanphamid && x.DanhMuc.DanhMucID == danhmucid).FirstOrDefault();
            return PartialView(item);
        }
        public ActionResult ChiTietSanPhamTheoThuongHieu(int thuonghieuid, int sanphamid)
        {
            ViewBag.thuonghieu = _dbContext.ThuongHieus.FirstOrDefault(x => x.ThuongHieuID == thuonghieuid).ThuongHieuName;
            var item = _dbContext.SanPhams.Where(x => x.SanPhamID == sanphamid && x.ThuongHieu.ThuongHieuID == thuonghieuid).FirstOrDefault();
            return PartialView(item);
        }

    }
}