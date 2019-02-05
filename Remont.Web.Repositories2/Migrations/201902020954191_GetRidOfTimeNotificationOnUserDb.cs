namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetRidOfTimeNotificationOnUserDb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "DateCreated");
            DropColumn("dbo.Users", "LastModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "LastModified", c => c.DateTime());
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime());
        }
    }
}
//public override void Up()
//{
//    Sql("insert into" +

//        " Users " +
//        "(Name," +
//        "LastName," +
//        "Birthdate," +
//        "Age," +
//        "City," +
//        "State," +
//        "PostalCode," +
//        "Country," +
//        "UserSpecializations," +
//        " UserPhoneNumber, " +
//        "UserEmailAdress," +
//        " UserYearsOfExperience," +
//        " DescriptionOfUser)" +

//        "values" +
//        "('Mati'," +
//        "'Kowal'," +
//        "'31.08.1993'," +
//        "26," +
//        "'Laszczow'," +
//        "'Dolnoslaskie'," +
//        "'59-300'," +
//        "'Poland'," +
//        "'Plumber'," +
//        " 1234555789, " +
//        "'test1@gmail.com', " +
//        "5, " +
//        "'First user in here')");

//    Sql("insert into" +

//       " Users " +
//       "(Name," +
//       "LastName," +
//       "Birthdate," +
//       "Age," +
//       "City," +
//       "State," +
//       "PostalCode," +
//       "Country," +
//       "(UserSpecializations," +
//       " UserPhoneNumber, " +
//       "UserEmailAdress," +
//       " UserYearsOfExperience," +
//       " DescriptionOfUser)" +

//       "values" +
//       "('Kacper'," +
//       "'Chlon'," +
//       "'08.04.1993'," +
//       "26," +
//       "'Wroclaw'," +
//       "'Lubelskie'," +
//       "'58-315'," +
//       "'Poland'," +
//       "'Painter'," +
//       " 2344225789, " +
//       "'test2@gmail.com', " +
//       "10, " +
//       "'Second user in here')");
//}

//public override void Down()
//{
//    Sql("delete from Users where UserEmailAdress = 'test1@gmail.com'");
//    Sql("delete from Users where UserEmailAdress = 'test2@gmail.com'");

//}