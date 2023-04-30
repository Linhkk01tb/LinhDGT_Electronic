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
        public ActionResult Index(int? page, string timkiem)
        {
            IEnumerable<SanPham> items = _dbContext.SanPhams.Where(x=>x.SanPhamStatus == 1).OrderByDescending(x => x.SanPhamID);
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
        public ActionResult LienHe()
        {
           
            return View();
        }
    }
}