namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.donhang", "KhachHangID");
            AddForeignKey("dbo.donhang", "KhachHangID", "dbo.khachhang", "KhachHangID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.donhang", "KhachHangID", "dbo.khachhang");
            DropIndex("dbo.donhang", new[] { "KhachHangID" });
        }
    }
}
