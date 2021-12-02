namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_SaPham : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SanPham", "TenLoaiSanPham", c => c.String(maxLength: 10));
            AddColumn("dbo.SanPham", "TenNhaSanXuat", c => c.String(maxLength: 10));
            AddColumn("dbo.SanPham", "LoaiSanPham_MaLoaiSanPham", c => c.String(maxLength: 10));
            AddColumn("dbo.SanPham", "NhaSanXuat_MaNhaSanXuat", c => c.String(maxLength: 10));
            CreateIndex("dbo.SanPham", "LoaiSanPham_MaLoaiSanPham");
            CreateIndex("dbo.SanPham", "NhaSanXuat_MaNhaSanXuat");
            AddForeignKey("dbo.SanPham", "LoaiSanPham_MaLoaiSanPham", "dbo.LoaiSanPham", "MaLoaiSanPham");
            AddForeignKey("dbo.SanPham", "NhaSanXuat_MaNhaSanXuat", "dbo.NhaSanXuat", "MaNhaSanXuat");
            DropColumn("dbo.SanPham", "MaLoaiSanPham");
            DropColumn("dbo.SanPham", "MaNhaSanXuat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SanPham", "MaNhaSanXuat", c => c.String(maxLength: 10));
            AddColumn("dbo.SanPham", "MaLoaiSanPham", c => c.String(maxLength: 10));
            DropForeignKey("dbo.SanPham", "NhaSanXuat_MaNhaSanXuat", "dbo.NhaSanXuat");
            DropForeignKey("dbo.SanPham", "LoaiSanPham_MaLoaiSanPham", "dbo.LoaiSanPham");
            DropIndex("dbo.SanPham", new[] { "NhaSanXuat_MaNhaSanXuat" });
            DropIndex("dbo.SanPham", new[] { "LoaiSanPham_MaLoaiSanPham" });
            DropColumn("dbo.SanPham", "NhaSanXuat_MaNhaSanXuat");
            DropColumn("dbo.SanPham", "LoaiSanPham_MaLoaiSanPham");
            DropColumn("dbo.SanPham", "TenNhaSanXuat");
            DropColumn("dbo.SanPham", "TenLoaiSanPham");
        }
    }
}
