namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToNullableDateTimeForAllClasses : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccountsRepository", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.AccountsRepository", "LastModified", c => c.DateTime());
            AlterColumn("dbo.UsersRepository", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.UsersRepository", "LastModified", c => c.DateTime());
            AlterColumn("dbo.Orders", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Orders", "LastModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "LastModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UsersRepository", "LastModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UsersRepository", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AccountsRepository", "LastModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AccountsRepository", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
