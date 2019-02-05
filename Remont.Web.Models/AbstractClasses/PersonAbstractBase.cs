using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models.AbstractClasses
{
    public abstract class PersonAbstractBase
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }
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
//        " DescriptionOfUser, " +
//        "DateCreated, " +
//        "LastModified)" +

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
//        "'First user in here'," +
//        "'02.01.2019 20:00:00'," +
//        "'02.01.2019 20:00:00')");

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
//       " DescriptionOfUser, " +
//       "DateCreated, " +
//       "LastModified)" +

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
//       "'Second user in here'," +
//       "'02.01.2019 20:00:00'," +
//       "'02.01.2019 20:00:00')");
//}

//public override void Down()
//{
//    Sql("delete from Users where UserEmailAdress = 'test1@gmail.com'");
//    Sql("delete from Users where UserEmailAdress = 'test2@gmail.com'");

//}