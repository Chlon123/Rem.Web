using Remont.Web.Models.AbstractClasses;
using Remont.Web.Models.Interfaces;
using Remont.Web.Models.ModelEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models
{
    public class User : PersonAbstractBase, IModificationHistory
    {
        [Key]
        public int UserId { get; set; }

        public string UserSpecializations { get; set; }

        public string UserPhoneNumber { get; set; }

        public string UserEmailAdressHash { get; set; }

        public int UserYearsOfExperience { get; set; }

        public string DescriptionOfUser { get; set; }

        public virtual ICollection<UsersLocalization> UserLocalizations { get; set; }

        public virtual ICollection<Account> UserAccount { get; set; }

        public virtual ICollection<Order> UserOrders { get; set; }

        public virtual ICollection<Avatar> UserAvatar { get; set; }

        public virtual ICollection<BankAccount> UserBankAccount { get; set; }

        public virtual ICollection<Grade> UserGrade { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? LastModified { get; set; }
    }
}

