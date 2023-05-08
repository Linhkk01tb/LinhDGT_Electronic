namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateall2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.donhang", "UserId");
            DropColumn("dbo.AspNetUsers", "Phone");
            DropColumn("dbo.AspNetUsers", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String());
            AddColumn("dbo.donhang", "UserId", c => c.String());
        }
    }
}
