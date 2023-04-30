using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinhDGT_Electronic.Models.EF
{
    [Table("anhsanpham")]
    public class AnhSanPham
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnhID { get; set; }
        public string AnhName { get; set; }
        public bool AnhStatus { get; set; }
        public int SanPhamID { get; set; }
        public virtual SanPham SanPham { get; set; }
        
    }
}