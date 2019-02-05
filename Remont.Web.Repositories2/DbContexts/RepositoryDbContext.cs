using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remont.Web.Models;

namespace Remont.Web.Repositories
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext()
            : base(DbContextsMagicStrings.GetConnectionStringForDbContexts())
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersLocalization> OrderLocalizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersLocalization> UserLocalizations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var _account = modelBuilder.Entity<Account>();
            var _avatar = modelBuilder.Entity<Avatar>();
            var _bankAccount = modelBuilder.Entity<BankAccount>();
            var _grade = modelBuilder.Entity<Grade>();
            var _order = modelBuilder.Entity<Order>();
            var _ordersLocalization = modelBuilder.Entity<OrdersLocalization>();
            var _user = modelBuilder.Entity<User>();
            var _usersLocalization = modelBuilder.Entity<UsersLocalization>();

            //Account settings
            _account
                 .Property(a => a.AccountEmailAsLogin)
                 .IsRequired();
            _account
                .Property(a => a.AccountPassword)
                .IsRequired();
            _account
                .Property(a => a.AccountOfUserId)
                .IsOptional();


            // Avatar settings
            _avatar
                .Property(a => a.AvatarOfUserId)
                .IsOptional();

            // Order settings
            _order
                .HasMany(o => o.OrdersLocalization)
                .WithOptional(ol => ol.LocalizationOfOrder)
                .HasForeignKey(ol => ol.LocalizationOfOrderId);

            // User settings
            _user.HasKey(kou => kou.UserId);

            _user
                .HasMany(u => u.UserAvatar)
                .WithOptional(a => a.AvatarOfUser)
                .HasForeignKey(u => u.AvatarOfUserId);

            _user
                .HasMany(u => u.UserBankAccount)
                .WithOptional(ba => ba.Owner)
                .HasForeignKey(ba => ba.OwnerId);


            _user
                .HasMany(u => u.UserAccount)
                .WithOptional(a => a.AccountOfUser)
                .HasForeignKey(a => a.AccountOfUserId);

            _user
                .HasMany(u => u.UserGrade)
                .WithOptional(g => g.GradeOfUser)
                .HasForeignKey(g => g.GradeOfUserId);


            _user
                 .HasMany(u => u.UserOrders)
                 .WithMany(o => o.OrdersOfUser)
                 .Map(uo =>
                 {
                     uo.ToTable("OrdersOfUser");
                     uo.MapLeftKey("UserId");
                     uo.MapRightKey("OrderId");
                 });

            _user
                .HasMany(u => u.UserLocalizations)
                .WithMany(l => l.LocalizationOfUsers)
                .Map(ul =>
                {
                    ul.ToTable("UserLocalizations");
                    ul.MapLeftKey("UserId");
                    ul.MapRightKey("LocalizationId");
                });

        }



    }
}
