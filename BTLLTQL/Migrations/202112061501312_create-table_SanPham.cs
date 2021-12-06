namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtable_SanPham : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "TenNhaSanXuat", "dbo.NhaSanXuat");
            DropForeignKey("dbo.SanPham", "TenLoaiSanPham", "dbo.LoaiSanPham");
            DropIndex("dbo.SanPham", new[] { "TenNhaSanXuat" });
            DropIndex("dbo.SanPham", new[] { "TenLoaiSanPham" });
            DropTable("dbo.NhaSanXuat");
            DropTable("dbo.SanPham");
            DropTable("dbo.LoaiSanPham");
        }
    }
}
