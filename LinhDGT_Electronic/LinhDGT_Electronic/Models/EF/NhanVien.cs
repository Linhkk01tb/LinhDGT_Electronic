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

        [Required]
        public string NhanVienCode { get; set; }
        [Required]
        public string NhanVienName { get; set; }
        [Required]
        public DateTime NhanVienBirth { get; set; }

        public int NhanVienGender { get; set; }

        public string NhanVienAddress { get; set; }
        [Required]
        [EmailAddress]
        public string NhanVienEmail { get; set; }

        public string NhanVienPhoneNumber { get; set; }

        public int NhanVienWorkingDate { get; set; }

        public double NhanVienSalary { get; set; }

        public int NhanVienStatus { get; set; }
    }
}