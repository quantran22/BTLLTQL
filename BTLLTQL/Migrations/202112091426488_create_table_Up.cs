namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Up : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DanhGias", "MaSanPham", c => c.Int(nullable: false));
            CreateIndex("dbo.DanhGias", "MaSanPham");
            AddForeignKey("dbo.DanhGias", "MaSanPham", "dbo.SanPham", "MaSanPham", cascadeDelete: true);
            DropColumn("dbo.DanhGias", "TenSanPham");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DanhGias", "TenSanPham", c => c.Int(nullable: false));
            DropForeignKey("dbo.DanhGias", "MaSanPham", "dbo.SanPham");
            DropIndex("dbo.DanhGias", new[] { "MaSanPham" });
            DropColumn("dbo.DanhGias", "MaSanPham");
        }
    }
}
