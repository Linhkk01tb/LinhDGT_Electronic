using LinhDGT_Electronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinhDGT_Electronic.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.sanpham = _context.SanPhams.ToList().Count();
            ViewBag.donhang = _context.DonHangs.ToList().Count();
            ViewBag.danhmuc = _context.DanhMucs.ToList().Count();
            ViewBag.thuonghieu = _context.ThuongHieus.ToList().Count();
            ViewBag.nhanvien = _context.NhanViens.ToList().Count();
            ViewBag.khachhang = _context.KhachHangs.ToList().Count();
            return View();
        }
    }
}