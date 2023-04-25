namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedanhmuc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.danhmuc", "DanhMucCode", c => c.String(nullable: false));
            AlterColumn("dbo.danhmuc", "DanhMucName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.danhmuc", "DanhMucName", c => c.String());
            AlterColumn("dbo.danhmuc", "DanhMucCode", c => c.String());
        }
    }
}
