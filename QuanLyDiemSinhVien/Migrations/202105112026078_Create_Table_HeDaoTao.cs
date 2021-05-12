namespace QuanLyDiemSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_HeDaoTao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HeDaoTaos",
                c => new
                    {
                        MaHeDaoTao = c.String(nullable: false, maxLength: 128, unicode: false),
                        TenHeDaoTao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaHeDaoTao);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HeDaoTaos");
        }
    }
}
