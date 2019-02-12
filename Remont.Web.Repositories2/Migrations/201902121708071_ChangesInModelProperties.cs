namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInModelProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "AccountEmailAsLoginHash", c => c.String(nullable: false));
            AddColumn("dbo.Accounts", "AccountPasswordHash", c => c.String(nullable: false));
            AddColumn("dbo.Users", "UserEmailAdressHash", c => c.String());
            AlterColumn("dbo.Avatars", "GraphicComponentCode", c => c.Binary());
            AlterColumn("dbo.Grades", "GraphicComponentCode", c => c.Binary());
            DropColumn("dbo.Accounts", "AccountEmailAsLogin");
            DropColumn("dbo.Accounts", "AccountPassword");
            DropColumn("dbo.Users", "UserEmailAdress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserEmailAdress", c => c.String());
            AddColumn("dbo.Accounts", "AccountPassword", c => c.String(nullable: false));
            AddColumn("dbo.Accounts", "AccountEmailAsLogin", c => c.String(nullable: false));
            AlterColumn("dbo.Grades", "GraphicComponentCode", c => c.Byte(nullable: false));
            AlterColumn("dbo.Avatars", "GraphicComponentCode", c => c.Byte(nullable: false));
            DropColumn("dbo.Users", "UserEmailAdressHash");
            DropColumn("dbo.Accounts", "AccountPasswordHash");
            DropColumn("dbo.Accounts", "AccountEmailAsLoginHash");
        }
    }
}
