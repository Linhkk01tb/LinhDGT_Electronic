using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinhDGT_Electronic.Models.EF
{
    [Table("nhanvien")]
    public class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NhanVienID { get; set; }
        [Required(ErrorMessage = "Tên nhân viên không được để rỗng!")]
        public string NhanVienName { get; set; }
        [Required(ErrorMessage = "Ngày sinh không được để rỗng!")]
        public DateTime NhanVienBirth { get; set; }

        public int NhanVienGender { get; set; }

        public string NhanVienAddress { get; set; }
        [Required(ErrorMessage = "Email không được để rỗng!")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng!")]
        public string NhanVienEmail { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để rỗng!")]
        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng!")]
        public string NhanVienPhoneNumber { get; set; }
        [Required(ErrorMessage = "Số ngày làm việc không được để rỗng!")]

        public int NhanVienWorkingDate { get; set; }
        [Required(ErrorMessage = "Lương không được để rỗng!")]

        public double NhanVienSalary { get; set; }

        public int NhanVienStatus { get; set; }
    }
}