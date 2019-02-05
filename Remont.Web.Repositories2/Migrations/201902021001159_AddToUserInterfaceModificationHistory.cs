namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToUserInterfaceModificationHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersRepository", "DateCreated", c => c.DateTime());
            AddColumn("dbo.UsersRepository", "LastModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsersRepository", "LastModified");
            DropColumn("dbo.UsersRepository", "DateCreated");
        }
    }
}
