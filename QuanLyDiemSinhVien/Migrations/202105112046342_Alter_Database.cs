namespace QuanLyDiemSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Database : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Diems", "MaSV", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("dbo.Diems", "MaMH", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("dbo.Lops", "MaKhoa", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("dbo.Lops", "MaHeDaoTao", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("dbo.Lops", "MaKhoaHoc", c => c.String(nullable: false, maxLength: 128, fixedLength: true, unicode: false));
            AlterColumn("dbo.SinhViens", "MaLop", c => c.String(nullable: false, maxLength: 128, unicode: false));
            CreateIndex("dbo.Diems", "MaSV");
            CreateIndex("dbo.Diems", "MaMH");
            CreateIndex("dbo.SinhViens", "MaLop");
            CreateIndex("dbo.Lops", "MaKhoa");
            CreateIndex("dbo.Lops", "MaHeDaoTao");
            CreateIndex("dbo.Lops", "MaKhoaHoc");
            AddForeignKey("dbo.Diems", "MaMH", "dbo.MonHocs", "MaMH", cascadeDelete: true);
            AddForeignKey("dbo.Diems", "MaSV", "dbo.SinhViens", "MaSV", cascadeDelete: true);
            AddForeignKey("dbo.Lops", "MaHeDaoTao", "dbo.HeDaoTaos", "MaHeDaoTao", cascadeDelete: true);
            AddForeignKey("dbo.Lops", "MaKhoaHoc", "dbo.KhoaHocs", "MaKhoaHoc", cascadeDelete: true);
            AddForeignKey("dbo.Lops", "MaKhoa", "dbo.Khoas", "MaKhoa", cascadeDelete: true);
            AddForeignKey("dbo.SinhViens", "MaLop", "dbo.Lops", "MaLop", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SinhViens", "MaLop", "dbo.Lops");
            DropForeignKey("dbo.Lops", "MaKhoa", "dbo.Khoas");
            DropForeignKey("dbo.Lops", "MaKhoaHoc", "dbo.KhoaHocs");
            DropForeignKey("dbo.Lops", "MaHeDaoTao", "dbo.HeDaoTaos");
            DropForeignKey("dbo.Diems", "MaSV", "dbo.SinhViens");
            DropForeignKey("dbo.Diems", "MaMH", "dbo.MonHocs");
            DropIndex("dbo.Lops", new[] { "MaKhoaHoc" });
            DropIndex("dbo.Lops", new[] { "MaHeDaoTao" });
            DropIndex("dbo.Lops", new[] { "MaKhoa" });
            DropIndex("dbo.SinhViens", new[] { "MaLop" });
            DropIndex("dbo.Diems", new[] { "MaMH" });
            DropIndex("dbo.Diems", new[] { "MaSV" });
            AlterColumn("dbo.SinhViens", "MaLop", c => c.String(nullable: false));
            AlterColumn("dbo.Lops", "MaKhoaHoc", c => c.String(nullable: false));
            AlterColumn("dbo.Lops", "MaHeDaoTao", c => c.String(nullable: false));
            AlterColumn("dbo.Lops", "MaKhoa", c => c.String(nullable: false));
            AlterColumn("dbo.Diems", "MaMH", c => c.String(nullable: false));
            AlterColumn("dbo.Diems", "MaSV", c => c.String(nullable: false));
        }
    }
}
