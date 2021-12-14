namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table_table_SanPham : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DanhGias", "khachhang_MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.DanhGias", "SanPham_MaSanPham", "dbo.SanPham");
            DropIndex("dbo.DanhGias", new[] { "khachhang_MaKH" });
            DropIndex("dbo.DanhGias", new[] { "SanPham_MaSanPham" });
            DropTable("dbo.DanhGias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DanhGias",
                c => new
                    {
                        MaSanPham = c.Int(nullable: false, identity: true),
                        MaKH = c.String(nullable: false),
                        Ngay_Gio = c.DateTime(nullable: false),
                        NoiDung = c.String(nullable: false),
                        Sđt = c.String(nullable: false),
                        khachhang_MaKH = c.Int(),
                        SanPham_MaSanPham = c.Int(),
                    })
                .PrimaryKey(t => t.MaSanPham);
            
            CreateIndex("dbo.DanhGias", "SanPham_MaSanPham");
            CreateIndex("dbo.DanhGias", "khachhang_MaKH");
            AddForeignKey("dbo.DanhGias", "SanPham_MaSanPham", "dbo.SanPham", "MaSanPham");
            AddForeignKey("dbo.DanhGias", "khachhang_MaKH", "dbo.KhachHang", "MaKH");
        }
    }
}
