namespace QuanLyDiemSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Khoa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Khoas", "Logo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Khoas", "Logo");
        }
    }
}
