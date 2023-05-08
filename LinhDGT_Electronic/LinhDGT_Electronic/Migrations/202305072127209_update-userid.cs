namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuserid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.donhang", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.donhang", "UserId");
        }
    }
}
