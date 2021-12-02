namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_Account : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        RoleID = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.LoaiSanPham",
                c => new
                    {
                        MaLoaiSanPham = c.String(nullable: false, maxLength: 10),
                        TenLoaiSanPham = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaLoaiSanPham);
            
            CreateTable(
                "dbo.NhaSanXuat",
                c => new
                    {
                        MaNhaSanXuat = c.String(nullable: false, maxLength: 10),
                        TenNhaSanXuat = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaNhaSanXuat);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSanPham = c.Int(nullable: false, identity: true),
                        MaLoaiSanPham = c.String(maxLength: 10),
                        MaNhaSanXuat = c.String(maxLength: 10),
                        TenSanPham = c.String(),
                        CauHinh = c.String(unicode: false, storeType: "text"),
                        HinhChinh = c.String(maxLength: 50),
                        Hinh1 = c.String(maxLength: 50),
                        Hinh2 = c.String(maxLength: 50),
                        Hinh3 = c.String(maxLength: 50),
                        Hinh4 = c.String(maxLength: 50),
                        Gia = c.Int(),
                        SoLuongBan = c.Int(),
                        LuotView = c.Int(),
                        TinhTrang = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.MaSanPham);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SanPham");
            DropTable("dbo.Roles");
            DropTable("dbo.NhaSanXuat");
            DropTable("dbo.LoaiSanPham");
            DropTable("dbo.Account");
        }
    }
}
