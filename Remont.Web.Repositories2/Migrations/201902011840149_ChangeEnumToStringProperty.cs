namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEnumToStringProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserSpecializations", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserSpecializations", c => c.Int(nullable: false));
        }
    }
}