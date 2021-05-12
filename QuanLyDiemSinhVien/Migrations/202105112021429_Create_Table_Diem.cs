namespace QuanLyDiemSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Diem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diems",
                c => new
                    {
                        HocKy = c.Int(nullable: false, identity: true),
                        MaSV = c.String(nullable: false),
                        MaMH = c.String(nullable: false),
                        DiemLan1 = c.Single(nullable: false),
                        DiemLan2 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.HocKy);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Diems");
        }
    }
}
