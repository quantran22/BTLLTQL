namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_LoaiSanPham : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HangHoas", "LoaiSanPham_MaLoaiSanPham", "dbo.LoaiSanPham");
            DropForeignKey("dbo.HangHoas", "NhaSanXuat_MaNhaSanXuat", "dbo.NhaSanXuat");
            DropForeignKey("dbo.SanPham", "LoaiSanPham_MaLoaiSanPham", "dbo.LoaiSanPham");
            DropForeignKey("dbo.SanPham", "NhaSanXuat_MaNhaSanXuat", "dbo.NhaSanXuat");
            DropIndex("dbo.HangHoas", new[] { "LoaiSanPham_MaLoaiSanPham" });
            DropIndex("dbo.HangHoas", new[] { "NhaSanXuat_MaNhaSanXuat" });
            DropIndex("dbo.SanPham", new[] { "LoaiSanPham_MaLoaiSanPham" });
            DropIndex("dbo.SanPham", new[] { "NhaSanXuat_MaNhaSanXuat" });
            DropTable("dbo.HangHoas");
            DropTable("dbo.SanPham");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSanPham = c.Int(nullable: false, identity: true),
                        TenLoaiSanPham = c.String(maxLength: 10),
                        TenNhaSanXuat = c.String(maxLength: 10),
                        TenSanPham = c.String(),
                        CauHinh = c.String(unicode: false, storeType: "text"),
                        HinhChinh = c.String(maxLength: 50),
                        Gia = c.Int(),
                        SoLuongBan = c.Int(),
                        TinhTrang = c.String(maxLength: 10),
                        LoaiSanPham_MaLoaiSanPham = c.String(maxLength: 10),
                        NhaSanXuat_MaNhaSanXuat = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.MaSanPham);
            
            CreateTable(
                "dbo.HangHoas",
                c => new
                    {
                        MaSanPham = c.Int(nullable: false, identity: true),
                        TenLoaiSanPham = c.String(maxLength: 10),
                        TenNhaSanXuat = c.String(maxLength: 10),
                        TenSanPham = c.String(),
                        CauHinh = c.String(unicode: false, storeType: "text"),
                        HinhChinh = c.String(maxLength: 50),
                        Gia = c.Int(),
                        SoLuongBan = c.Int(),
                        TinhTrang = c.String(maxLength: 10),
                        LoaiSanPham_MaLoaiSanPham = c.String(maxLength: 10),
                        NhaSanXuat_MaNhaSanXuat = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.MaSanPham);
            
            CreateIndex("dbo.SanPham", "NhaSanXuat_MaNhaSanXuat");
            CreateIndex("dbo.SanPham", "LoaiSanPham_MaLoaiSanPham");
            CreateIndex("dbo.HangHoas", "NhaSanXuat_MaNhaSanXuat");
            CreateIndex("dbo.HangHoas", "LoaiSanPham_MaLoaiSanPham");
            AddForeignKey("dbo.SanPham", "NhaSanXuat_MaNhaSanXuat", "dbo.NhaSanXuat", "MaNhaSanXuat");
            AddForeignKey("dbo.SanPham", "LoaiSanPham_MaLoaiSanPham", "dbo.LoaiSanPham", "MaLoaiSanPham");
            AddForeignKey("dbo.HangHoas", "NhaSanXuat_MaNhaSanXuat", "dbo.NhaSanXuat", "MaNhaSanXuat");
            AddForeignKey("dbo.HangHoas", "LoaiSanPham_MaLoaiSanPham", "dbo.LoaiSanPham", "MaLoaiSanPham");
        }
    }
}
