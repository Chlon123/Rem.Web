namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToUserInterfaceModificationHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime());
            AddColumn("dbo.Users", "LastModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LastModified");
            DropColumn("dbo.Users", "DateCreated");
        }
    }
}
