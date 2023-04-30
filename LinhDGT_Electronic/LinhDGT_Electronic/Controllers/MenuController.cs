using LinhDGT_Electronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinhDGT_Electronic.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuDanhMuc()
        {
            var item = _dbContext.DanhMucs.Where(x => x.DanhMucStatus == 1).OrderByDescending(x => x.DanhMucID).ToList();
            return PartialView("_MenuDanhMuc", item);
        }
        public ActionResult MenuThuongHieu()
        {
            var item = _dbContext.ThuongHieus.Where(x => x.ThuongHieuStatus == 1).OrderByDescending(x => x.ThuongHieuID).ToList();
            return PartialView("_MenuThuongHieu", item);
        }

    }
}