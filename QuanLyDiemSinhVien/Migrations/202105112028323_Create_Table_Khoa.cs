namespace QuanLyDiemSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Khoa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Khoas",
                c => new
                    {
                        MaKhoa = c.String(nullable: false, maxLength: 128, unicode: false),
                        TenKhoa = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        DienThoai = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaKhoa);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Khoas");
        }
    }
}
