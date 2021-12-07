namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_LoaiSanPham : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SanPham", "TenLoaiSanPham", "dbo.LoaiSanPham");
            DropForeignKey("dbo.SanPham", "TenNhaSanXuat", "dbo.NhaSanXuat");
            RenameColumn(table: "dbo.SanPham", name: "TenLoaiSanPham", newName: "MaLoaiSanPham");
            RenameColumn(table: "dbo.SanPham", name: "TenNhaSanXuat", newName: "MaNhaSanXuat");
            RenameIndex(table: "dbo.SanPham", name: "IX_TenLoaiSanPham", newName: "IX_MaLoaiSanPham");
            RenameIndex(table: "dbo.SanPham", name: "IX_TenNhaSanXuat", newName: "IX_MaNhaSanXuat");
            DropPrimaryKey("dbo.LoaiSanPham");
            DropPrimaryKey("dbo.NhaSanXuat");
            AlterColumn("dbo.LoaiSanPham", "TenLoaiSanPham", c => c.String());
            AlterColumn("dbo.LoaiSanPham", "MaLoaiSanPham", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.NhaSanXuat", "TenNhaSanXuat", c => c.String());
            AlterColumn("dbo.NhaSanXuat", "MaNhaSanXuat", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.LoaiSanPham", "MaLoaiSanPham");
            AddPrimaryKey("dbo.NhaSanXuat", "MaNhaSanXuat");
            AddForeignKey("dbo.SanPham", "MaLoaiSanPham", "dbo.LoaiSanPham", "MaLoaiSanPham");
            AddForeignKey("dbo.SanPham", "MaNhaSanXuat", "dbo.NhaSanXuat", "MaNhaSanXuat");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "MaNhaSanXuat", "dbo.NhaSanXuat");
            DropForeignKey("dbo.SanPham", "MaLoaiSanPham", "dbo.LoaiSanPham");
            DropPrimaryKey("dbo.NhaSanXuat");
            DropPrimaryKey("dbo.LoaiSanPham");
            AlterColumn("dbo.NhaSanXuat", "MaNhaSanXuat", c => c.String());
            AlterColumn("dbo.NhaSanXuat", "TenNhaSanXuat", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.LoaiSanPham", "MaLoaiSanPham", c => c.String());
            AlterColumn("dbo.LoaiSanPham", "TenLoaiSanPham", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.NhaSanXuat", "TenNhaSanXuat");
            AddPrimaryKey("dbo.LoaiSanPham", "TenLoaiSanPham");
            RenameIndex(table: "dbo.SanPham", name: "IX_MaNhaSanXuat", newName: "IX_TenNhaSanXuat");
            RenameIndex(table: "dbo.SanPham", name: "IX_MaLoaiSanPham", newName: "IX_TenLoaiSanPham");
            RenameColumn(table: "dbo.SanPham", name: "MaNhaSanXuat", newName: "TenNhaSanXuat");
            RenameColumn(table: "dbo.SanPham", name: "MaLoaiSanPham", newName: "TenLoaiSanPham");
            AddForeignKey("dbo.SanPham", "TenNhaSanXuat", "dbo.NhaSanXuat", "TenNhaSanXuat");
            AddForeignKey("dbo.SanPham", "TenLoaiSanPham", "dbo.LoaiSanPham", "TenLoaiSanPham");
        }
    }
}
