namespace QuanLyDiemSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_SinhVien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        MaSV = c.String(nullable: false, maxLength: 128, unicode: false),
                        TenSV = c.String(nullable: false),
                        GioiTinh = c.String(nullable: false),
                        NgaySinh = c.DateTime(nullable: false),
                        MaLop = c.String(nullable: false),
                        QueQuan = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaSV);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SinhViens");
        }
    }
}
