using LinhDGT_Electronic.Models;
using LinhDGT_Electronic.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace LinhDGT_Electronic.Controllers
{ 
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        public ActionResult Index(int? page, string timkiem, string boloc, string sapxep)
        {
            ViewBag.sapxep = sapxep;
            ViewBag.sapxeptheoten = String.IsNullOrEmpty(sapxep) ? "ten_desc" : "";
            ViewBag.sapxeptheogia = sapxep == "gia" ? "gia_desc" : "gia";
            ViewBag.sapxeptheonamsanxuat = sapxep == "namsx" ? "namsx_desc" : "namsx";
            ViewBag.sapxeptheosoluong = sapxep == "soluong" ? "soluong_desc" : "soluong";
            ViewBag.sapxeptheongaytao = sapxep == "ngaytao" ? "ngaytao_desc" : "ngaytao";
            IEnumerable<SanPham> items = _dbContext.SanPhams.OrderByDescending(x => x.SanPhamID);
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
        public ActionResult LienHe()
        {
           
            return View();
        }
    }
}