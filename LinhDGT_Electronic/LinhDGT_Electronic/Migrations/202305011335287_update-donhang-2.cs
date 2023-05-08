namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedonhang2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.donhang", "DonHangPayment", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.donhang", "DonHangPayment");
        }
    }
}
