namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDatabaseOfUsers : DbMigration
    {
        public override void Up()
        {
            Sql("insert into UsersRepository (Name, LastName, Birthdate, Age, City, State, PostalCode, Country, UserSpecializations, UserPhoneNumber, " +
                " UserEmailAdress, UserYearsOfExperience, DescriptionOfUser, DateCreated, LastModified) values " +

                "('Mati', 'Kowal', '01.02.1994 12:46:00', 26, 'Laszczow', 'Lubelski', '53-620', 'Poland', 'Plumber', 1234555789, " +
                "'test1@gmail.com', 5, 'First user in here', '01.02.2019 12:46:00', '01.02.2019 12:46:00')");

            Sql("insert into UsersRepository (Name, LastName, Birthdate, Age, City, State, PostalCode, Country, UserSpecializations, UserPhoneNumber, " +
                " UserEmailAdress, UserYearsOfExperience, DescriptionOfUser, DateCreated, LastModified) values " +
                "('Kapi', 'Chlon', '01.02.1995 10:48:00', 26, 'Lubin', 'Dolnoslaskie', '59-300', 'Poland', 'Painter', 9234566789, " +
                "'test2@gmail.com', 5, 'Second user in here', '01.01.2019 12:40:00', '01.01.2019 12:40:00')");

        }

        public override void Down()
        {
            Sql("delete from UsersRepository where UserEmailAdress = 'test1@gmail.com'");
            Sql("delete from UsersRepository where UserEmailAdress = 'test2@gmail.com'");

        }
    }
}
