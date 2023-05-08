using LinhDGT_Electronic.Models;
using LinhDGT_Electronic.Models.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinhDGT_Electronic.Controllers
{
    [Authorize(Roles = "Admin,Customer")]
    public class GioHangController : Controller
    {   

        private ApplicationDbContext _dbcontext = new ApplicationDbContext();
        // GET: GioHang
        /// <summary>
        /// Màn hình giỏ hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            GioHangViewModels gioHang = (GioHangViewModels)Session["GioHang"];
            if (gioHang != null)
            {
                return View(gioHang.Items);
            }
            return View();
        }

        public ActionResult DatHang()
        {
            return View();
        }

        /// <summary>
        /// Màn hình form đặt hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult DatHangForm()
        {
            return View();
        }

        /// <summary>
        /// Màn hình đặt hàng thành công
        /// </summary>
        /// <returns></returns>
        public ActionResult DatHangThanhCong()
        {
            return View();
        }

        /// <summary>
        /// Màn hình thông tin mua hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult ThongTinMuaHang()
        {
            GioHangViewModels gioHang = (GioHangViewModels)Session["GioHang"];
            if (gioHang != null)
            {
                return View(gioHang.Items);
            }
            return View();
        }

        /// <summary>
        /// HIển thị số lượng trong giỏ hàng lên màn hình thông báo
        /// </summary>
        /// <returns>Số lượng hàng thêm vào giỏ</returns>
        public ActionResult HienThiSoLuongTrongGioHang()
        {
            GioHangViewModels gioHang = (GioHangViewModels)Session["GioHang"];
            if (gioHang != null)
            {
                return Json(new { count = gioHang.Items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { count = 0 }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Chức năng đặt hàng và gửi mail cho khách hàng và admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DatHang(DonHangViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                model.DonHangPayment = 1;
                GioHangViewModels gioHang = (GioHangViewModels)Session["GioHang"];
                if (gioHang != null)
                {
                    DonHang donHang = new DonHang();
                    donHang.DonHangReceiverName = model.DonHangReceiverName;
                    donHang.DonHangReceiverEmail = model.DonHangReceiverEmail;
                    donHang.DonHangReceiverAddress = model.DonHangReceiverAddress;
                    donHang.DonHangReceiverPhoneNumber = model.DonHangReceiverPhoneNumber;
                    gioHang.Items.ForEach(x => donHang.ChiTietDonHangs.Add(new ChiTietDonHang
                    {
                        SanPhamID = x.SanPhamID,
                        SoLuongMua = x.SanPhamBuyQuantity,
                        ThanhTien = x.Total,
                    }));


                    //Lấy sản phẩm trong giỏ hàng giỏ hàng là session
                    foreach(var item in gioHang.Items)
                    {
                        //Lấy sản phẩm trong bảng sản phẩm
                        foreach(var item1 in _dbcontext.SanPhams)
                        {
                            // So sánh id sản phẩm
                            if(item1.SanPhamID == item.SanPhamID)
                            {
                                //Cập nhật sản phẩm trong bảng sản phẩm
                                item1.SanPhamSellQuantity += item.SanPhamBuyQuantity;
                                item1.SanPhamQuantity -= item.SanPhamBuyQuantity;
                                _dbcontext.Entry(item1).Property(x=>x.SanPhamQuantity).IsModified = true;
                                _dbcontext.Entry(item1).Property(x => x.SanPhamSellQuantity).IsModified = true;
                            }
                        }
                    }


                    donHang.DonHangTotalPayment = gioHang.Items.Sum(x => (x.SanPhamUnitPrice * x.SanPhamBuyQuantity));
                    donHang.DonHangPayment = model.DonHangPayment;
                    Random rd = new Random();
                    donHang.DonHangCode = "DH" + rd.Next(0, 99) + +rd.Next(0, 99) + rd.Next(0, 99) + rd.Next(0, 99);
                    donHang.DonHangCreatedDate = DateTime.Now;
                    donHang.DonHangModifiedDate = DateTime.Now;
                    donHang.DonHangStatus = 0;
                    donHang.UserId = _dbcontext.Users.First(x=>x.UserName == User.Identity.Name).UserName;
                    _dbcontext.DonHangs.Add(donHang);
                    _dbcontext.SaveChanges();

                    //Gửi mail đặt hàng cho khách
                    var strSanPham = "";
                    var thanhtien = 0.0;
                    var tongthanhtoan = 0.0;
                    var phuongthucthanhtoan = "";
                    if (model.DonHangPayment == 1) phuongthucthanhtoan = "Thanh toán khi nhận hàng";
                    foreach (var item in gioHang.Items)
                    {
                        strSanPham += "<tr>";
                        strSanPham += "<td>"+ item.SanPhamName +"</td>";
                        strSanPham += "<td>" + item.SanPhamBuyQuantity + "</td>";
                        strSanPham += "<td>" + item.SanPhamUnitPrice.ToString("0,0 VNĐ") + "</td>";
                        strSanPham += "</tr>";
                        thanhtien += item.SanPhamUnitPrice * item.SanPhamBuyQuantity;
                    }
                    tongthanhtoan = thanhtien;
                    string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/Content/templeMail/send2.html"));
                    contentCustomer = contentCustomer.Replace("{{madonhang}}",donHang.DonHangCode);
                    contentCustomer = contentCustomer.Replace("{{sanpham}}", strSanPham);
                    contentCustomer = contentCustomer.Replace("{{thanhtien}}", thanhtien.ToString("0,0 VNĐ"));
                    contentCustomer = contentCustomer.Replace("{{tongthanhtoan}}", tongthanhtoan.ToString("0,0 VNĐ"));
                    contentCustomer = contentCustomer.Replace("{{tennguoinhan}}", donHang.DonHangReceiverName);
                    contentCustomer = contentCustomer.Replace("{{email}}", donHang.DonHangReceiverEmail);
                    contentCustomer = contentCustomer.Replace("{{sodienthoai}}", donHang.DonHangReceiverPhoneNumber);
                    contentCustomer = contentCustomer.Replace("{{diachi}}", donHang.DonHangReceiverAddress);
                    contentCustomer = contentCustomer.Replace("{{ngaydathang}}", donHang.DonHangCreatedDate.ToString("dd/MM/yyyy HH:mm"));
                    contentCustomer = contentCustomer.Replace("{{phuongthucthanhtoan}}", phuongthucthanhtoan);
                    Common.Common.SendEmail("LinhDGT Electronic", "Đơn hàng #" + donHang.DonHangCode,contentCustomer.ToString(),model.DonHangReceiverEmail) ;
                    //gửi mail cho Admin
                    string contentAdmin = System.IO.File.ReadAllText(Server.MapPath("~/Content/templeMail/send1.html"));
                    contentAdmin = contentAdmin.Replace("{{madonhang}}", donHang.DonHangCode);
                    contentAdmin = contentAdmin.Replace("{{sanpham}}", strSanPham);
                    contentAdmin = contentAdmin.Replace("{{thanhtien}}", thanhtien.ToString("0,0 VNĐ"));
                    contentAdmin = contentAdmin.Replace("{{tongthanhtoan}}", tongthanhtoan.ToString("0,0 VNĐ"));
                    contentAdmin = contentAdmin.Replace("{{tennguoinhan}}", donHang.DonHangReceiverName);
                    contentAdmin = contentAdmin.Replace("{{email}}", donHang.DonHangReceiverEmail);
                    contentAdmin = contentAdmin.Replace("{{sodienthoai}}", donHang.DonHangReceiverPhoneNumber);
                    contentAdmin = contentAdmin.Replace("{{diachi}}", donHang.DonHangReceiverAddress);
                    contentAdmin = contentAdmin.Replace("{{ngaydathang}}", donHang.DonHangCreatedDate.ToString("dd/MM/yyyy HH:mm"));
                    contentAdmin = contentAdmin.Replace("{{phuongthucthanhtoan}}", phuongthucthanhtoan);
                    Common.Common.SendEmail("LinhDGT Electronic", "Đơn hàng mới #" + donHang.DonHangCode, contentAdmin.ToString(), ConfigurationManager.AppSettings["EmailAdmin"]);
                    gioHang.DonSachGioHang();
                    return RedirectToAction("DatHangThanhCong");
                }
            }
            return View(model);
        }
        /// <summary>
        /// Chức năng thêm hàng vào giỏ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="soluongmua"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ThemVaoGioHang(int id, int soluongmua)
        {
            var code = new { success = false, msg = "", code = -1, count = 0 };

            var _dbContext = new ApplicationDbContext();
            var checkSanPham = _dbContext.SanPhams.FirstOrDefault(x => x.SanPhamID == id);
            if (checkSanPham != null)
            {
                GioHangViewModels giohang = (GioHangViewModels)Session["GioHang"];
                if (giohang == null)
                {
                    giohang = new GioHangViewModels();

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
        /// <summary>
        /// Chức năng xoá hàng khỏi giỏ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult XoaSanPham(int id)
        {
            var code = new { success = false, msg = "", code = -1, count = 0 };
            GioHangViewModels gioHang = (GioHangViewModels)Session["GioHang"];
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
        /// <summary>
        /// Chức năng xoá tất cả hàng ra khỏi giỏ
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult XoaTatCa()
        {
            GioHangViewModels gioHang = (GioHangViewModels)Session["GioHang"];
            if (gioHang != null)
            {
                gioHang.DonSachGioHang();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }


    }
}
