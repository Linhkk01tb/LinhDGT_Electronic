using LinhDGT_Electronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinhDGT_Electronic.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            GioHang gioHang = (GioHang)Session["GioHang"];
            if (gioHang != null)
            {
                return View(gioHang.Items);
            }
            return View();
        }

        public ActionResult HienThiSoLuongTrongGioHang()
        {
            GioHang gioHang = (GioHang)Session["GioHang"];
            if (gioHang != null)
            {
                return Json(new { count = gioHang.Items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { count = 0 }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ThemVaoGioHang(int id, int soluongmua)
        {
            var code = new { success = false, msg = "", code = -1, count = 0 };

            var _dbContext = new ApplicationDbContext();
            var checkSanPham = _dbContext.SanPhams.FirstOrDefault(x => x.SanPhamID == id);
            if (checkSanPham != null)
            {
                GioHang giohang = (GioHang)Session["GioHang"];
                if (giohang == null)
                {
                    giohang = new GioHang();

                }
                GioHangItem item = new GioHangItem
                {
                    SanPhamID = checkSanPham.SanPhamID,
                    SanPhameImage = checkSanPham.SanPhamImage,
                    SanPhamName = checkSanPham.SanPhamName,
                    SanPhamUnitPrice = checkSanPham.SanPhamUnitPrice,
                    SanPhamBuyQuantity = soluongmua,

                };

                item.Total = item.SanPhamBuyQuantity * item.SanPhamUnitPrice;
                giohang.ThemVaoGioHang(item, soluongmua);
                Session["GioHang"] = giohang;
                code = new { success = true, msg = "Đã thêm sản phẩm vào giỏ hàng!", code = 1, count = giohang.Items.Count };

            }
            return Json(code);
        }
        [HttpPost]
        public ActionResult XoaSanPham(int id)
        {
            var code = new { success = false, msg = "", code = -1, count = 0 };
            GioHang gioHang = (GioHang)Session["GioHang"];
            if (gioHang != null)
            {
                var checkSanPham = gioHang.Items.FirstOrDefault(x => x.SanPhamID == id);
                if (checkSanPham != null)
                {
                    gioHang.XoaKhoiGioHang(id);
                    code = new { success = true, msg = "Đã xoá!", code = 1, count = gioHang.Items.Count };
                }
            }
            return Json(code);
        }
    }
}
