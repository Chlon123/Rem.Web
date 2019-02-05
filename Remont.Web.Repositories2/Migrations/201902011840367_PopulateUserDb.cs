namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserDb : DbMigration
    {
        public override void Up()
        {
            Sql("insert into AccountsRepository (AccountEmailAsLogin, AccountPassword, DateCreated, LastModified, ReturnUrl)" +
                " values ('test1@gmail.com', 'test1', '01.02.2019 19:45:00', '01.02.2019 19:45:00', 'http://localhost:53350/Home/Index')");

            Sql("insert into AccountsRepository (AccountEmailAsLogin, AccountPassword, DateCreated, LastModified, ReturnUrl)" +
               " values ('test2@gmail.com', 'test2', '01.02.2019 19:45:00', '01.02.2019 19:46:00', 'http://localhost:53350/Home/Index')");
        }
        
        public override void Down()
        {
            Sql("delete from AccountsRepository where AccountEmailAsLogin = 'test1@gmail.com'");
            Sql("delete from AccountsRepository where AccountEmailAsLogin = 'test2@gmail.com'");

        }
    }
}
