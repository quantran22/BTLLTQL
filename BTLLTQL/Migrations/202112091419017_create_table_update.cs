namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DanhGias", "khachhang_MaKH", "dbo.KhachHang");
            DropIndex("dbo.DanhGias", new[] { "khachhang_MaKH" });
            DropColumn("dbo.DanhGias", "MaKH");
            RenameColumn(table: "dbo.DanhGias", name: "khachhang_MaKH", newName: "MaKH");
            AlterColumn("dbo.DanhGias", "MaKH", c => c.Int(nullable: false));
            AlterColumn("dbo.DanhGias", "MaKH", c => c.Int(nullable: false));
            CreateIndex("dbo.DanhGias", "MaKH");
            AddForeignKey("dbo.DanhGias", "MaKH", "dbo.KhachHang", "MaKH", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DanhGias", "MaKH", "dbo.KhachHang");
            DropIndex("dbo.DanhGias", new[] { "MaKH" });
            AlterColumn("dbo.DanhGias", "MaKH", c => c.Int());
            AlterColumn("dbo.DanhGias", "MaKH", c => c.String());
            RenameColumn(table: "dbo.DanhGias", name: "MaKH", newName: "khachhang_MaKH");
            AddColumn("dbo.DanhGias", "MaKH", c => c.String());
            CreateIndex("dbo.DanhGias", "khachhang_MaKH");
            AddForeignKey("dbo.DanhGias", "khachhang_MaKH", "dbo.KhachHang", "MaKH");
        }
    }
}
