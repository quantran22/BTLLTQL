namespace BTLLTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_KhachHang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        TenKhachHang = c.String(maxLength: 50),
                        Sđt = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Diachi = c.String(maxLength: 50),
                        Hinh1 = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaKH);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KhachHang");
        }
    }
}
