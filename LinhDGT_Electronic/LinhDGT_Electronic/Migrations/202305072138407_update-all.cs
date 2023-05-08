namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateall : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.donhang", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.donhang", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.donhang", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.donhang", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.donhang", "ApplicationUser_Id");
            AddForeignKey("dbo.donhang", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
