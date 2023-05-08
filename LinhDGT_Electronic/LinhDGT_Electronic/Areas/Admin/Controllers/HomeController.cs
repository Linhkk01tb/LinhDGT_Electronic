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
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var tongdoanhthu = 0.0;

            ViewBag.sanpham = _context.SanPhams.ToList().Count();
            ViewBag.donhang = _context.DonHangs.ToList().Count();
            ViewBag.danhmuc = _context.DanhMucs.ToList().Count();
            ViewBag.thuonghieu = _context.ThuongHieus.ToList().Count();
            ViewBag.nhanvien = _context.NhanViens.ToList().Count();
            ViewBag.taikhoan = _context.Users.ToList().Count();
            foreach (var item1 in _context.DonHangs)
            {
                if (item1 != null)
                {
                    foreach (var item in _context.ChiTietDonHangs)
                    {
                        if (item.DonHangID == item1.DonHangID)
                        {
                            tongdoanhthu += item.ThanhTien;
                        }
                    }
                }
            }
            ViewBag.thanhtien = tongdoanhthu;

            return View();
        }
        public ActionResult ThongKeDoanhThu(int? page, string timkiem, string boloc, string sapxep)
        {
            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheosoluong = String.IsNullOrEmpty(sapxep) ? "soluong" : "";
            ViewBag.sapxeptheoten = sapxep == "ten" ? "gia_desc" : "ten";
            IEnumerable<SanPham> items = _context.SanPhams.OrderByDescending(x => x.SanPhamID);
            var pagesize = 10;
            if (timkiem != null)
            {
                page = 1;
            }
            else
            {
                timkiem = boloc;
            }
            double tongdoanhthu = 0.0;
            foreach(var item in items) {
                tongdoanhthu += item.SanPhamSellQuantity * item.SanPhamUnitPrice;
            }
            ViewBag.tongdoanhthu = tongdoanhthu;
            ViewBag.boloc = boloc;
            switch (sapxep)
            {
                case "ten":
                    items = items.OrderBy(p => p.SanPhamName);
                    break;
                case "ten_desc":
                    items = items.OrderByDescending(p => p.SanPhamName);
                    break;
                case "soluong":
                    items = items.OrderBy(p => p.SanPhamSellQuantity);
                    break;
                default:
                    items = items.OrderByDescending(p => p.SanPhamSellQuantity);
                    break;
            }
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                items = items.Where(x => x.SanPhamName.ToLower().Contains(timkiem));
            }
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            var pagenumber = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pagenumber, pagesize);
            return View(items);
        }
    }
}