using LinhDGT_Electronic.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LinhDGT_Electronic.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PhanQuyenController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Admin/PhanQuyen
        public ActionResult Index()
        {
            var item = _dbContext.Roles.ToList();
            return View(item);
        }

        public ActionResult ThemQuyenHan()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemQuyenHan(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                var phanquyen = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
                phanquyen.Create(model);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult SuaQuyenHan(string id)
        {
            var item = _dbContext.Roles.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaQuyenHan(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                var phanquyen = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
                phanquyen.Update(model);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult XoaQuyenHan(string id)
        {
            var item = _dbContext.Roles.Find(id);

            if (item != null)
            {
                _dbContext.Roles.Remove(item);
                _dbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}