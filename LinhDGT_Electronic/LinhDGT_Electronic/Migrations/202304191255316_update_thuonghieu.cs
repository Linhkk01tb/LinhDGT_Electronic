namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_thuonghieu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.thuonghieu", "ThuongHieuStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.thuonghieu", "ThuongHieuStatus", c => c.Boolean(nullable: false));
        }
    }
}
