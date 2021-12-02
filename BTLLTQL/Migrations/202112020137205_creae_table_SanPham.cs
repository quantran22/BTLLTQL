namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creae_table_SanPham : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SanPham", "Hinh1");
            DropColumn("dbo.SanPham", "Hinh2");
            DropColumn("dbo.SanPham", "Hinh3");
            DropColumn("dbo.SanPham", "Hinh4");
            DropColumn("dbo.SanPham", "LuotView");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SanPham", "LuotView", c => c.Int());
            AddColumn("dbo.SanPham", "Hinh4", c => c.String(maxLength: 50));
            AddColumn("dbo.SanPham", "Hinh3", c => c.String(maxLength: 50));
            AddColumn("dbo.SanPham", "Hinh2", c => c.String(maxLength: 50));
            AddColumn("dbo.SanPham", "Hinh1", c => c.String(maxLength: 50));
        }
    }
}
