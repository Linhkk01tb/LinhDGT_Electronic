namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedonhang1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.donhang", "DonHangReceiverEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.donhang", "DonHangReceiverEmail");
        }
    }
}
