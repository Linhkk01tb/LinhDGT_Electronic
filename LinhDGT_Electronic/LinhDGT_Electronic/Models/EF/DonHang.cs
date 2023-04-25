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
        [Required]
        public string DonHangCode { get; set; }
        [Required]
        public string DonHangReceiverName { get; set; }
        [Required]
        public string DonHangReceiverPhoneNumber { get; set; }
        [Required]
        public string DonHangReceiverAddress { get; set; }
        public double DonHangTotalPayment { get; set; }
        public int DonHangStatus { get; set; }
        
        public int KhachHangID { get; set; }
        public DateTime DonHangCreatedDate { get; set; }
        public DateTime DonHangModifiedDate { get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}