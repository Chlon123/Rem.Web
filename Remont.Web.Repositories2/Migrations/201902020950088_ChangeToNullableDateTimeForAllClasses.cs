namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToNullableDateTimeForAllClasses : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Accounts", "LastModified", c => c.DateTime());
            AlterColumn("dbo.Users", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Users", "LastModified", c => c.DateTime());
            AlterColumn("dbo.Orders", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Orders", "LastModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "LastModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "LastModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Accounts", "LastModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Accounts", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
