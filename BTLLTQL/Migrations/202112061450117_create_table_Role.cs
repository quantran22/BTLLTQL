namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Role : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SanPham", "LoaiSanPham_MaLoaiSanPham", "dbo.LoaiSanPham");
            DropForeignKey("dbo.SanPham", "NhaSanXuat_MaNhaSanXuat", "dbo.NhaSanXuat");
            DropIndex("dbo.SanPham", new[] { "LoaiSanPham_MaLoaiSanPham" });
            DropIndex("dbo.SanPham", new[] { "NhaSanXuat_MaNhaSanXuat" });
            DropTable("dbo.LoaiSanPham");
            DropTable("dbo.SanPham");
            DropTable("dbo.NhaSanXuat");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NhaSanXuat",
                c => new
                    {
                        MaNhaSanXuat = c.String(nullable: false, maxLength: 128),
                        TenNhaSanXuat = c.String(),
                    })
                .PrimaryKey(t => t.MaNhaSanXuat);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSanPham = c.Int(nullable: false, identity: true),
                        TenLoaiSanPham = c.String(),
                        TenNhaSanXuat = c.String(),
                        TenSanPham = c.String(),
                        CauHinh = c.String(unicode: false, storeType: "text"),
                        HinhChinh = c.String(maxLength: 50),
                        Gia = c.Int(),
                        SoLuongBan = c.Int(),
                        GioiThieu = c.String(),
                        LoaiSanPham_MaLoaiSanPham = c.String(maxLength: 128),
                        NhaSanXuat_MaNhaSanXuat = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaSanPham);
            
            CreateTable(
                "dbo.LoaiSanPham",
                c => new
                    {
                        MaLoaiSanPham = c.String(nullable: false, maxLength: 128),
                        TenLoaiSanPham = c.String(),
                    })
                .PrimaryKey(t => t.MaLoaiSanPham);
            
            CreateIndex("dbo.SanPham", "NhaSanXuat_MaNhaSanXuat");
            CreateIndex("dbo.SanPham", "LoaiSanPham_MaLoaiSanPham");
            AddForeignKey("dbo.SanPham", "NhaSanXuat_MaNhaSanXuat", "dbo.NhaSanXuat", "MaNhaSanXuat");
            AddForeignKey("dbo.SanPham", "LoaiSanPham_MaLoaiSanPham", "dbo.LoaiSanPham", "MaLoaiSanPham");
        }
    }
}
