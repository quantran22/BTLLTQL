namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_SanPham : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "Password", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.SanPham", "TinhTrang", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SanPham", "TinhTrang", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.Account", "Password", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
