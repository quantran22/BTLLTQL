namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_SanPham : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        RoleID = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        TenKhachHang = c.String(maxLength: 50),
                        Sđt = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Diachi = c.String(maxLength: 50),
                        Hinh1 = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.LoaiSanPham",
                c => new
                    {
                        TenLoaiSanPham = c.String(nullable: false, maxLength: 128),
                        MaLoaiSanPham = c.String(),
                    })
                .PrimaryKey(t => t.TenLoaiSanPham);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSanPham = c.Int(nullable: false, identity: true),
                        TenLoaiSanPham = c.String(maxLength: 128),
                        TenNhaSanXuat = c.String(maxLength: 128),
                        TenSanPham = c.String(),
                        CauHinh = c.String(unicode: false, storeType: "text"),
                        HinhChinh = c.String(maxLength: 50),
                        Gia = c.Int(),
                        SoLuongBan = c.Int(),
                        GioiThieu = c.String(),
                    })
                .PrimaryKey(t => t.MaSanPham)
                .ForeignKey("dbo.LoaiSanPham", t => t.TenLoaiSanPham)
                .ForeignKey("dbo.NhaSanXuat", t => t.TenNhaSanXuat)
                .Index(t => t.TenLoaiSanPham)
                .Index(t => t.TenNhaSanXuat);
            
            CreateTable(
                "dbo.NhaSanXuat",
                c => new
                    {
                        TenNhaSanXuat = c.String(nullable: false, maxLength: 128),
                        MaNhaSanXuat = c.String(),
                    })
                .PrimaryKey(t => t.TenNhaSanXuat);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "TenNhaSanXuat", "dbo.NhaSanXuat");
            DropForeignKey("dbo.SanPham", "TenLoaiSanPham", "dbo.LoaiSanPham");
            DropIndex("dbo.SanPham", new[] { "TenNhaSanXuat" });
            DropIndex("dbo.SanPham", new[] { "TenLoaiSanPham" });
            DropTable("dbo.Roles");
            DropTable("dbo.NhaSanXuat");
            DropTable("dbo.SanPham");
            DropTable("dbo.LoaiSanPham");
            DropTable("dbo.KhachHang");
            DropTable("dbo.Account");
        }
    }
}
