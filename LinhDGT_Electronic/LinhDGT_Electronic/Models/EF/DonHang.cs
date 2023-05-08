using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinhDGT_Electronic.Models.EF
{
    [Table("donhang")]
    public class DonHang
    {
        public DonHang() {
            this.ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DonHangID { get; set; }
        public string DonHangCode { get; set; }
        [Required(ErrorMessage = "Tên người nhận không được để trống!")]
        public string DonHangReceiverName { get; set; }
        [Required(ErrorMessage ="Số điện thoại không được để trống!")]
        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng!")]
        public string DonHangReceiverPhoneNumber { get; set; }
        [Required(ErrorMessage = "Địa chỉ email không được để trống!")]
        [EmailAddress(ErrorMessage ="Email không đúng định dạng!")]
        public string DonHangReceiverEmail { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống!")]
        public string DonHangReceiverAddress { get; set; }
        public double DonHangTotalPayment { get; set; }
        public int DonHangPayment { get; set; }
        public int DonHangStatus { get; set; }
        public DateTime DonHangCreatedDate { get; set; }
        public DateTime DonHangModifiedDate { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

    }
}

