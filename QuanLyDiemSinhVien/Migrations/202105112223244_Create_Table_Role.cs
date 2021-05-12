namespace QuanLyDiemSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Role : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Articles");
            CreateTable(
                "dbo.AccountModels",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128, unicode: false),
                        Password = c.String(nullable: false),
                        RoleID = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 128, unicode: false),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AlterColumn("dbo.Articles", "ArticleID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Articles", "ArticleID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Articles");
            AlterColumn("dbo.Articles", "ArticleID", c => c.String(nullable: false, maxLength: 128, unicode: false));
            DropTable("dbo.Roles");
            DropTable("dbo.AccountModels");
            AddPrimaryKey("dbo.Articles", "ArticleID");
        }
    }
}
