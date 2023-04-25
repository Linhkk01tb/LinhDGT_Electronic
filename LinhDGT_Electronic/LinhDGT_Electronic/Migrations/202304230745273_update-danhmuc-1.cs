namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedanhmuc1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.sanpham", "SanPhamCode", c => c.String(nullable: false));
            AlterColumn("dbo.sanpham", "SanPhamName", c => c.String(nullable: false));
            AlterColumn("dbo.sanpham", "SanPhamImage", c => c.String(nullable: false));
            AlterColumn("dbo.sanpham", "SanPhamProducedYear", c => c.String(nullable: false));
            AlterColumn("dbo.thuonghieu", "ThuongHieuCode", c => c.String(nullable: false));
            AlterColumn("dbo.thuonghieu", "ThuongHieuName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.thuonghieu", "ThuongHieuName", c => c.String());
            AlterColumn("dbo.thuonghieu", "ThuongHieuCode", c => c.String());
            AlterColumn("dbo.sanpham", "SanPhamProducedYear", c => c.String());
            AlterColumn("dbo.sanpham", "SanPhamImage", c => c.String());
            AlterColumn("dbo.sanpham", "SanPhamName", c => c.String());
            AlterColumn("dbo.sanpham", "SanPhamCode", c => c.String());
        }
    }
}
