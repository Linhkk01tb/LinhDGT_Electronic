using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinhDGT_Electronic.Models.EF
{
    [Table("khachhang")]
    public class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KhachHangID { get; set; }

        [Required]
        public string KhachHangCode { get; set; }
        [Required]
        public string KhachHangUserName { get; set; }
        [Required]
        public string KhachHangPassword { get; set; }

        public string KhachHangName { get; set; }
        [Required]
        [EmailAddress]
        public string KhachHangEmail { get; set; }

        public string KhachHangPhoneNumber { get; set; }

        public string KhachHangAddress { get; set; }

        public int KhachHangStatus { get; set; }

          
    }
}