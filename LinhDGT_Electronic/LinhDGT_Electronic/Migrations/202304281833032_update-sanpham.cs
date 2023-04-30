namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesanpham : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.sanpham", "SanPhamImage", c => c.String(nullable: false));
            AlterColumn("dbo.sanpham", "SanPhamProducedYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.sanpham", "SanPhamProducedYear", c => c.String(nullable: false));
            AlterColumn("dbo.sanpham", "SanPhamImage", c => c.String());
        }
    }
}
