namespace Remont.Web.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrationForTheDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountsRepository",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        AccountEmailAsLogin = c.String(nullable: false),
                        AccountPassword = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        AccountOfUserId = c.Int(),
                        ReturnUrl = c.String(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.UsersRepository", t => t.AccountOfUserId)
                .Index(t => t.AccountOfUserId);
            
            CreateTable(
                "dbo.UsersRepository",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserSpecializations = c.Int(nullable: false),
                        UserPhoneNumber = c.Int(nullable: false),
                        UserEmailAdress = c.String(),
                        UserYearsOfExperience = c.Int(nullable: false),
                        DescriptionOfUser = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        Name = c.String(),
                        LastName = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.Int(nullable: false),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Avatars",
                c => new
                    {
                        AvatarId = c.Int(nullable: false, identity: true),
                        GraphicComponentName = c.String(),
                        GraphicComponentCode = c.Byte(nullable: false),
                        AvatarOfUserId = c.Int(),
                    })
                .PrimaryKey(t => t.AvatarId)
                .ForeignKey("dbo.UsersRepository", t => t.AvatarOfUserId)
                .Index(t => t.AvatarOfUserId);
            
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        BankAccountId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(),
                        BankAccountIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankAccountOutcome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankAccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BankAccountId)
                .ForeignKey("dbo.UsersRepository", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GraphicComponentName = c.String(),
                        GraphicComponentCode = c.Byte(nullable: false),
                        GradeOfUserId = c.Int(),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.UsersRepository", t => t.GradeOfUserId)
                .Index(t => t.GradeOfUserId);
            
            CreateTable(
                "dbo.UsersLocalizations",
                c => new
                    {
                        UsersLocalizationId = c.Int(nullable: false, identity: true),
                        LocalizationName = c.String(),
                    })
                .PrimaryKey(t => t.UsersLocalizationId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderSpecialization = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        OrderTitle = c.String(),
                        OrderInfo = c.String(),
                        OrderMinimalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderMaximalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.OrdersLocalizations",
                c => new
                    {
                        OrdersLocalizationId = c.Int(nullable: false, identity: true),
                        LocalizationOfOrderId = c.Int(),
                        LocalizationName = c.String(),
                    })
                .PrimaryKey(t => t.OrdersLocalizationId)
                .ForeignKey("dbo.Orders", t => t.LocalizationOfOrderId)
                .Index(t => t.LocalizationOfOrderId);
            
            CreateTable(
                "dbo.UserLocalizations",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        LocalizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.LocalizationId })
                .ForeignKey("dbo.UsersRepository", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UsersLocalizations", t => t.LocalizationId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.LocalizationId);
            
            CreateTable(
                "dbo.OrdersOfUser",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.OrderId })
                .ForeignKey("dbo.UsersRepository", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdersOfUser", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrdersOfUser", "UserId", "dbo.UsersRepository");
            DropForeignKey("dbo.OrdersLocalizations", "LocalizationOfOrderId", "dbo.Orders");
            DropForeignKey("dbo.UserLocalizations", "LocalizationId", "dbo.UsersLocalizations");
            DropForeignKey("dbo.UserLocalizations", "UserId", "dbo.UsersRepository");
            DropForeignKey("dbo.Grades", "GradeOfUserId", "dbo.UsersRepository");
            DropForeignKey("dbo.BankAccounts", "OwnerId", "dbo.UsersRepository");
            DropForeignKey("dbo.Avatars", "AvatarOfUserId", "dbo.UsersRepository");
            DropForeignKey("dbo.AccountsRepository", "AccountOfUserId", "dbo.UsersRepository");
            DropIndex("dbo.OrdersOfUser", new[] { "OrderId" });
            DropIndex("dbo.OrdersOfUser", new[] { "UserId" });
            DropIndex("dbo.UserLocalizations", new[] { "LocalizationId" });
            DropIndex("dbo.UserLocalizations", new[] { "UserId" });
            DropIndex("dbo.OrdersLocalizations", new[] { "LocalizationOfOrderId" });
            DropIndex("dbo.Grades", new[] { "GradeOfUserId" });
            DropIndex("dbo.BankAccounts", new[] { "OwnerId" });
            DropIndex("dbo.Avatars", new[] { "AvatarOfUserId" });
            DropIndex("dbo.AccountsRepository", new[] { "AccountOfUserId" });
            DropTable("dbo.OrdersOfUser");
            DropTable("dbo.UserLocalizations");
            DropTable("dbo.OrdersLocalizations");
            DropTable("dbo.Orders");
            DropTable("dbo.UsersLocalizations");
            DropTable("dbo.Grades");
            DropTable("dbo.BankAccounts");
            DropTable("dbo.Avatars");
            DropTable("dbo.UsersRepository");
            DropTable("dbo.AccountsRepository");
        }
    }
}
