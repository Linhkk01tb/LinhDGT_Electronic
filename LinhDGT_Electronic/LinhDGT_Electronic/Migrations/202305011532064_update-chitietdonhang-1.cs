namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatechitietdonhang1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.chitietdonhang", "SoLuongMua", c => c.Int(nullable: false));
            AlterColumn("dbo.chitietdonhang", "ThanhTien", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.chitietdonhang", "ThanhTien", c => c.String());
            AlterColumn("dbo.chitietdonhang", "SoLuongMua", c => c.String());
        }
    }
}
