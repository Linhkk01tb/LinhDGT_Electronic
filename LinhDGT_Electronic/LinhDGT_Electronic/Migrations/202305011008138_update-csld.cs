namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecsld : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.donhang", "KhachHangID", "dbo.khachhang");
            DropIndex("dbo.donhang", new[] { "KhachHangID" });
            DropColumn("dbo.donhang", "KhachHangID");
            DropTable("dbo.khachhang");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.khachhang",
                c => new
                    {
                        KhachHangID = c.Int(nullable: false, identity: true),
                        KhachHangUserName = c.String(nullable: false),
                        KhachHangPassword = c.String(nullable: false),
                        KhachHangName = c.String(),
                        KhachHangEmail = c.String(nullable: false),
                        KhachHangPhoneNumber = c.String(),
                        KhachHangAddress = c.String(),
                        KhachHangStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KhachHangID);
            
            AddColumn("dbo.donhang", "KhachHangID", c => c.Int(nullable: false));
            CreateIndex("dbo.donhang", "KhachHangID");
            AddForeignKey("dbo.donhang", "KhachHangID", "dbo.khachhang", "KhachHangID", cascadeDelete: true);
        }
    }
}
