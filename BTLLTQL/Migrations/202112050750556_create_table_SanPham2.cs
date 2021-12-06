namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_SanPham2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SanPham", "GioiThieu", c => c.String());
            DropColumn("dbo.SanPham", "TinhTrang");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SanPham", "TinhTrang", c => c.String(maxLength: 10));
            DropColumn("dbo.SanPham", "GioiThieu");
        }
    }
}
