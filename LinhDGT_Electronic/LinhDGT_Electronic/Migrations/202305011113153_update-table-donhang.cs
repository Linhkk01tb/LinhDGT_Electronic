namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetabledonhang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.donhang", "DonHangCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.donhang", "DonHangCode");
        }
    }
}
