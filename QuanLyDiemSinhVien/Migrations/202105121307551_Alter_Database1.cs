namespace QuanLyDiemSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Database1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Articles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleID = c.String(nullable: false, maxLength: 128),
                        Author = c.String(),
                        ArticleContent = c.String(),
                    })
                .PrimaryKey(t => t.ArticleID);
            
        }
    }
}
