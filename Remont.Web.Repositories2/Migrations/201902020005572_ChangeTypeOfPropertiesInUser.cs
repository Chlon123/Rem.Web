namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeOfPropertiesInUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "PostalCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PostalCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.Int(nullable: false));
        }
    }
}
