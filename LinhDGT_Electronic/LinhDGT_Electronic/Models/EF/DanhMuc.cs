using LinhDGT_Electronic.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace LinhDGT_Electronic.Models.EF
{
    [Table("danhmuc")]
    public class DanhMuc
    {
        public DanhMuc()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DanhMucID { get; set; }
        [Required(ErrorMessage ="Mã danh mục không được để trống!")]
        public string DanhMucCode { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống!")]
        public string DanhMucName { get; set; }
        
        [AllowHtml]
        public string DanhMucDescription { get; set; }
        public int DanhMucStatus { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}