namespace QuanLyDiemSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Lop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lops",
                c => new
                    {
                        MaLop = c.String(nullable: false, maxLength: 128, unicode: false),
                        TenLop = c.String(nullable: false),
                        MaKhoa = c.String(nullable: false),
                        MaHeDaoTao = c.String(nullable: false),
                        MaKhoaHoc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaLop);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lops");
        }
    }
}
