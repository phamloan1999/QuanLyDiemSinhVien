namespace QuanLyDiemSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Column_Diem_DiemTrungBinh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diems", "DiemTrungBinh", c => c.Single(nullable: false));
            AddColumn("dbo.Diems", "XepLoai", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Diems", "XepLoai");
            DropColumn("dbo.Diems", "DiemTrungBinh");
        }
    }
}
