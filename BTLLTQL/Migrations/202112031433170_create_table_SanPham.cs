namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_SanPham : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.MaSanPham)
                .ForeignKey("dbo.LoaiSanPham", t => t.LoaiSanPham_MaLoaiSanPham)
                .ForeignKey("dbo.NhaSanXuat", t => t.NhaSanXuat_MaNhaSanXuat)
                .Index(t => t.LoaiSanPham_MaLoaiSanPham)
                .Index(t => t.NhaSanXuat_MaNhaSanXuat);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "NhaSanXuat_MaNhaSanXuat", "dbo.NhaSanXuat");
            DropForeignKey("dbo.SanPham", "LoaiSanPham_MaLoaiSanPham", "dbo.LoaiSanPham");
            DropIndex("dbo.SanPham", new[] { "NhaSanXuat_MaNhaSanXuat" });
            DropIndex("dbo.SanPham", new[] { "LoaiSanPham_MaLoaiSanPham" });
            DropTable("dbo.SanPham");
        }
    }
}
