namespace QuanLyDiemSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_KhoaHoc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KhoaHocs",
                c => new
                    {
                        MaKhoaHoc = c.String(nullable: false, maxLength: 128, fixedLength: true, unicode: false),
                        TenKhoaHoc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaKhoaHoc);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KhoaHocs");
        }
    }
}
