using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinhDGT_Electronic.Models.EF
{
    [Table("chitietdonhang")]
    public class ChiTietDonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChiTietDonHangID { get; set; }
        public int DonHangID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuongMua { get; set; }
        public double ThanhTien { get; set; }

        public virtual DonHang DonHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}