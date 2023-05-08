namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesanphamsellquantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.sanpham", "SanPhamSellQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.sanpham", "SanPhamSellQuantity");
        }
    }
}
