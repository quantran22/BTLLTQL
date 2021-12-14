namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_table_DG : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DanhGias", new[] { "Khachhang_MaKH" });
            CreateIndex("dbo.DanhGias", "khachhang_MaKH");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DanhGias", new[] { "khachhang_MaKH" });
            CreateIndex("dbo.DanhGias", "Khachhang_MaKH");
        }
    }
}
