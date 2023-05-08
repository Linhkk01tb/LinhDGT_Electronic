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
        public ActionResult SanPhamTheoDanhMuc(int? page, string timkiem, string boloc, string sapxep, int danhmucid)
        {
            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheoten = String.IsNullOrEmpty(sapxep) ? "ten_desc" : "";
            ViewBag.sapxeptheogia = sapxep == "gia" ? "gia_desc" : "gia";
            ViewBag.sapxeptheonamsanxuat = sapxep == "namsx" ? "namsx_desc" : "namsx";
            ViewBag.sapxeptheosoluong = sapxep == "soluong" ? "soluong_desc" : "soluong";
            ViewBag.sapxeptheongaytao = sapxep == "ngaytao" ? "ngaytao_desc" : "ngaytao";
            IEnumerable<SanPham> items = _dbContext.SanPhams.Where(x => x.DanhMucID == danhmucid && x.SanPhamStatus == 1).OrderByDescending(x => x.SanPhamID);
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
                    items = items.OrderByDescending(p => p.SanPhamName);
                    break;
                case "gia":
                    items = items.OrderBy(p => p.SanPhamUnitPrice);
                    break;
                case "gia_desc":
                    items = items.OrderByDescending(p => p.SanPhamUnitPrice);
                    break;
                case "namsx":
                    items = items.OrderBy(p => p.SanPhamProducedYear);
                    break;
                case "namsx_desc":
                    items = items.OrderByDescending(p => p.SanPhamProducedYear);
                    break;
                case "soluong":
                    items = items.OrderBy(p => p.SanPhamQuantity);
                    break;
                case "soluong_desc":
                    items = items.OrderByDescending(p => p.SanPhamQuantity);
                    break;
                case "ngaytao":
                    items = items.OrderBy(p => p.SanPhamID);
                    break;
                case "ngaytao_desc":
                    items = items.OrderByDescending(p => p.SanPhamID);
                    break;
                default:
                    items = items.OrderBy(p => p.SanPhamName);
                    break;
            }
            ViewBag.name = _dbContext.DanhMucs.Where(x => x.DanhMucID == danhmucid).FirstOrDefault().DanhMucName;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                items = items.Where(x => x.SanPhamName.ToLower().Contains(timkiem));
            }
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            return View(items);
        }
        public ActionResult SanPhamTheoThuongHieu(int? page, string timkiem, string boloc, string sapxep, int thuonghieuid)
        {
            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheoten = String.IsNullOrEmpty(sapxep) ? "ten_desc" : "";
            ViewBag.sapxeptheogia = sapxep == "gia" ? "gia_desc" : "gia";
            ViewBag.sapxeptheonamsanxuat = sapxep == "namsx" ? "namsx_desc" : "namsx";
            ViewBag.sapxeptheosoluong = sapxep == "soluong" ? "soluong_desc" : "soluong";
            ViewBag.sapxeptheongaytao = sapxep == "ngaytao" ? "ngaytao_desc" : "ngaytao";
            IEnumerable<SanPham> items = _dbContext.SanPhams.Where(x => x.ThuongHieuID == thuonghieuid && x.SanPhamStatus == 1).OrderByDescending(x => x.SanPhamID);
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
                    items = items.OrderByDescending(p => p.SanPhamName);
                    break;
                case "gia":
                    items = items.OrderBy(p => p.SanPhamUnitPrice);
                    break;
                case "gia_desc":
                    items = items.OrderByDescending(p => p.SanPhamUnitPrice);
                    break;
                case "namsx":
                    items = items.OrderBy(p => p.SanPhamProducedYear);
                    break;
                case "namsx_desc":
                    items = items.OrderByDescending(p => p.SanPhamProducedYear);
                    break;
                case "soluong":
                    items = items.OrderBy(p => p.SanPhamQuantity);
                    break;
                case "soluong_desc":
                    items = items.OrderByDescending(p => p.SanPhamQuantity);
                    break;
                case "ngaytao":
                    items = items.OrderBy(p => p.SanPhamID);
                    break;
                case "ngaytao_desc":
                    items = items.OrderByDescending(p => p.SanPhamID);
                    break;
                default:
                    items = items.OrderBy(p => p.SanPhamName);
                    break;
            }
            ViewBag.name = _dbContext.ThuongHieus.Where(x => x.ThuongHieuID == thuonghieuid).FirstOrDefault().ThuongHieuName;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                items = items.Where(x => x.SanPhamName.ToLower().Contains(timkiem));
            }
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            return View(items);
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