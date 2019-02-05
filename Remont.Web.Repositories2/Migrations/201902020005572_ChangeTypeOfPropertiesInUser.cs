namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeOfPropertiesInUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UsersRepository", "LastName", c => c.String());
            AlterColumn("dbo.UsersRepository", "PostalCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UsersRepository", "PostalCode", c => c.Int(nullable: false));
            AlterColumn("dbo.UsersRepository", "LastName", c => c.Int(nullable: false));
        }
    }
}
