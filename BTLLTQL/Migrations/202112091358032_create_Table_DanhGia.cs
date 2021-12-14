namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_Table_DanhGia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DanhGias",
                c => new
                    {
                        MaDanhGia = c.Int(nullable: false, identity: true),
                        TenSanPham = c.Int(nullable: false),
                        MaKH = c.String(),
                        Ngay_Gio = c.DateTime(nullable: false),
                        NoiDung = c.String(nullable: false),
                        Sđt = c.String(),
                        khachhang_MaKH = c.Int(),
                    })
                .PrimaryKey(t => t.MaDanhGia)
                .ForeignKey("dbo.KhachHang", t => t.khachhang_MaKH)
                .Index(t => t.khachhang_MaKH);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DanhGias", "khachhang_MaKH", "dbo.KhachHang");
            DropIndex("dbo.DanhGias", new[] { "khachhang_MaKH" });
            DropTable("dbo.DanhGias");
        }
    }
}
