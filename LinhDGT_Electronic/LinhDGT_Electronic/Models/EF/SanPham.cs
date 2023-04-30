using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinhDGT_Electronic.Models.EF
{
    [Table("sanpham")]
    public class SanPham
    {
        public SanPham() {
            this.AnhSanPhams = new HashSet<AnhSanPham>();
            this.ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SanPhamID { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được rỗng!")]
        public string SanPhamName { get; set; }

        [Required(ErrorMessage ="Ảnh đại diện là trường bắt buộc!")]
        public string SanPhamImage { get; set; }
        [Required(ErrorMessage = "Năm sản xuất không được rỗng!")]
        public int SanPhamProducedYear { get; set; }

        [AllowHtml]
        public string SanPhamDescription { get; set; }
        public int DanhMucID { get; set; }
        public int ThuongHieuID { get; set; }
        [Required(ErrorMessage = "Số lượng không được rỗng!")]
        public int SanPhamQuantity { get; set; }
        [Required(ErrorMessage = "Đơn giá không được rỗng!")]
        public double SanPhamUnitPrice { get; set; }
        public int SanPhamStatus { get; set; }
        public virtual DanhMuc DanhMuc { get; set;}
        public virtual ThuongHieu ThuongHieu { get; set;}
        public virtual ICollection<AnhSanPham> AnhSanPhams { get;set; }

        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get;set; }
    }
}