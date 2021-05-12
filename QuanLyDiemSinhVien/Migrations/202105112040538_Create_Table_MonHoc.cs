namespace QuanLyDiemSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_MonHoc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        MaMH = c.String(nullable: false, maxLength: 128, unicode: false),
                        TenMH = c.String(nullable: false),
                        SoTinChi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaMH);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MonHocs");
        }
    }
}
