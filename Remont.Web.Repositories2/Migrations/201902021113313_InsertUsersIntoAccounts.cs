namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertUsersIntoAccounts : DbMigration
    {
        public override void Up()
        {
            Sql("update Accounts set AccountOfUserId = 23 where accountId = 1");
            Sql("update Accounts set AccountOfUserId = 24 where accountId = 2");
        }

        public override void Down()
        {
            Sql("update Accounts set AccountOfUserId = NULL where accountId = 1");
            Sql("update Accounts set AccountOfUserId = NULL where accountId = 2");
        }
    }
}
