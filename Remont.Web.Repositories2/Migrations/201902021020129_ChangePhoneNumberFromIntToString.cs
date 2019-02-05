namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePhoneNumberFromIntToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserPhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserPhoneNumber", c => c.Int(nullable: false));
        }
    }
}
