namespace LinhDGT_Electronic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.anhsanpham",
                c => new
                    {
                        AnhID = c.Int(nullable: false, identity: true),
                        AnhCode = c.String(),
                        AnhName = c.String(),
                        AnhStatus = c.Int(nullable: false),
                        SanPhamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnhID)
                .ForeignKey("dbo.sanpham", t => t.SanPhamID, cascadeDelete: true)
                .Index(t => t.SanPhamID);
            
            CreateTable(
                "dbo.sanpham",
                c => new
                    {
                        SanPhamID = c.Int(nullable: false, identity: true),
                        SanPhamCode = c.String(),
                        SanPhamName = c.String(),
                        SanPhamImage = c.String(),
                        SanPhamProducedYear = c.String(),
                        SanPhamDescription = c.String(),
                        DanhMucID = c.Int(nullable: false),
                        ThuongHieuID = c.Int(nullable: false),
                        SanPhamQuantity = c.Int(nullable: false),
                        SanPhamUnitPrice = c.Double(nullable: false),
                        SanPhamStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SanPhamID)
                .ForeignKey("dbo.danhmuc", t => t.DanhMucID, cascadeDelete: true)
                .ForeignKey("dbo.thuonghieu", t => t.ThuongHieuID, cascadeDelete: true)
                .Index(t => t.DanhMucID)
                .Index(t => t.ThuongHieuID);
            
            CreateTable(
                "dbo.danhmuc",
                c => new
                    {
                        DanhMucID = c.Int(nullable: false, identity: true),
                        DanhMucCode = c.String(),
                        DanhMucName = c.String(),
                        DanhMucDescription = c.String(),
                        DanhMucStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DanhMucID);
            
            CreateTable(
                "dbo.thuonghieu",
                c => new
                    {
                        ThuongHieuID = c.Int(nullable: false, identity: true),
                        ThuongHieuCode = c.String(),
                        ThuongHieuName = c.String(),
                        ThuongHieuDescription = c.String(),
                        ThuongHieuStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ThuongHieuID);
            
            CreateTable(
                "dbo.donhang",
                c => new
                    {
                        DonHangID = c.Int(nullable: false, identity: true),
                        DonHangCode = c.String(nullable: false),
                        DonHangReceiverName = c.String(nullable: false),
                        DonHangReceiverPhoneNumber = c.String(nullable: false),
                        DonHangReceiverAddress = c.String(nullable: false),
                        DonHangTotalPayment = c.Double(nullable: false),
                        DonHangStatus = c.Int(nullable: false),
                        KhachHangID = c.Int(nullable: false),
                        DonHangCreatedDate = c.DateTime(nullable: false),
                        DonHangModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DonHangID);
            
            CreateTable(
                "dbo.chitietdonhang",
                c => new
                    {
                        ChiTietDonHangID = c.Int(nullable: false, identity: true),
                        DonHangID = c.Int(nullable: false),
                        SanPhamID = c.String(),
                        SoLuongMua = c.String(),
                        ThanhTien = c.String(),
                        SanPham_SanPhamID = c.Int(),
                    })
                .PrimaryKey(t => t.ChiTietDonHangID)
                .ForeignKey("dbo.donhang", t => t.DonHangID, cascadeDelete: true)
                .ForeignKey("dbo.sanpham", t => t.SanPham_SanPhamID)
                .Index(t => t.DonHangID)
                .Index(t => t.SanPham_SanPhamID);
            
            CreateTable(
                "dbo.khachhang",
                c => new
                    {
                        KhachHangID = c.Int(nullable: false, identity: true),
                        KhachHangCode = c.String(nullable: false),
                        KhachHangUserName = c.String(nullable: false),
                        KhachHangPassword = c.String(nullable: false),
                        KhachHangName = c.String(),
                        KhachHangEmail = c.String(nullable: false),
                        KhachHangPhoneNumber = c.String(),
                        KhachHangAddress = c.String(),
                        KhachHangStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KhachHangID);
            
            CreateTable(
                "dbo.nhanvien",
                c => new
                    {
                        NhanVienID = c.Int(nullable: false, identity: true),
                        NhanVienCode = c.String(nullable: false),
                        NhanVienName = c.String(nullable: false),
                        NhanVienBirth = c.DateTime(nullable: false),
                        NhanVienGender = c.Int(nullable: false),
                        NhanVienAddress = c.String(),
                        NhanVienEmail = c.String(nullable: false),
                        NhanVienPhoneNumber = c.String(),
                        NhanVienWorkingDate = c.Int(nullable: false),
                        NhanVienSalary = c.Double(nullable: false),
                        NhanVienStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NhanVienID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.chitietdonhang", "SanPham_SanPhamID", "dbo.sanpham");
            DropForeignKey("dbo.chitietdonhang", "DonHangID", "dbo.donhang");
            DropForeignKey("dbo.sanpham", "ThuongHieuID", "dbo.thuonghieu");
            DropForeignKey("dbo.sanpham", "DanhMucID", "dbo.danhmuc");
            DropForeignKey("dbo.anhsanpham", "SanPhamID", "dbo.sanpham");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.chitietdonhang", new[] { "SanPham_SanPhamID" });
            DropIndex("dbo.chitietdonhang", new[] { "DonHangID" });
            DropIndex("dbo.sanpham", new[] { "ThuongHieuID" });
            DropIndex("dbo.sanpham", new[] { "DanhMucID" });
            DropIndex("dbo.anhsanpham", new[] { "SanPhamID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.nhanvien");
            DropTable("dbo.khachhang");
            DropTable("dbo.chitietdonhang");
            DropTable("dbo.donhang");
            DropTable("dbo.thuonghieu");
            DropTable("dbo.danhmuc");
            DropTable("dbo.sanpham");
            DropTable("dbo.anhsanpham");
        }
    }
}
