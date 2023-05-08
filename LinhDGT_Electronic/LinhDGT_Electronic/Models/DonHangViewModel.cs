using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinhDGT_Electronic.Models
{
    public class DonHangViewModel
    {
        [Required(ErrorMessage = "Tên người nhận không được để trống!")]
        public string DonHangReceiverName { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng!")]
        public string DonHangReceiverPhoneNumber { get; set; }
        [Required(ErrorMessage = "Địa chỉ email không được để trống!")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng!")]
        public string DonHangReceiverEmail { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống!")]
        public string DonHangReceiverAddress { get; set; }
        public int DonHangPayment { get; set; }
    }
}