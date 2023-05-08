namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatechitietsanpham : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.chitietdonhang", "SanPham_SanPhamID", "dbo.sanpham");
            DropIndex("dbo.chitietdonhang", new[] { "SanPham_SanPhamID" });
            DropColumn("dbo.chitietdonhang", "SanPhamID");
            RenameColumn(table: "dbo.chitietdonhang", name: "SanPham_SanPhamID", newName: "SanPhamID");
            AlterColumn("dbo.chitietdonhang", "SanPhamID", c => c.Int(nullable: false));
            AlterColumn("dbo.chitietdonhang", "SanPhamID", c => c.Int(nullable: false));
            CreateIndex("dbo.chitietdonhang", "SanPhamID");
            AddForeignKey("dbo.chitietdonhang", "SanPhamID", "dbo.sanpham", "SanPhamID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.chitietdonhang", "SanPhamID", "dbo.sanpham");
            DropIndex("dbo.chitietdonhang", new[] { "SanPhamID" });
            AlterColumn("dbo.chitietdonhang", "SanPhamID", c => c.Int());
            AlterColumn("dbo.chitietdonhang", "SanPhamID", c => c.String());
            RenameColumn(table: "dbo.chitietdonhang", name: "SanPhamID", newName: "SanPham_SanPhamID");
            AddColumn("dbo.chitietdonhang", "SanPhamID", c => c.String());
            CreateIndex("dbo.chitietdonhang", "SanPham_SanPhamID");
            AddForeignKey("dbo.chitietdonhang", "SanPham_SanPhamID", "dbo.sanpham", "SanPhamID");
        }
    }
}
