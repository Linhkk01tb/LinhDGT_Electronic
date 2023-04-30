namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upadtenhanvien : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.nhanvien", "NhanVienPhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.nhanvien", "NhanVienPhoneNumber", c => c.String());
        }
    }
}
