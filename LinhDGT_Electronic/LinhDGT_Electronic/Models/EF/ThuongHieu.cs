using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinhDGT_Electronic.Models.EF
{
    [Table("thuonghieu")]
    public class ThuongHieu
    {
        public ThuongHieu()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ThuongHieuID { get; set; }
        [Required(ErrorMessage = "Mã thương hiệu không được rỗng!")]
        public string ThuongHieuCode { get; set; }
        [Required(ErrorMessage = "Tên thương hiệu không được rỗng!")]
        public string ThuongHieuName { get; set; }

        [System.Web.Mvc.AllowHtml]
        public string ThuongHieuDescription { get; set; }
        public int ThuongHieuStatus { get; set; }
        public ICollection<SanPham> SanPhams { get; set;}
    }
}