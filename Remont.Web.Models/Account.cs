using Remont.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models
{
    public class Account : IModificationHistory
    {
        [Key]
        public int AccountId { get; set; }

        [DataType(DataType.EmailAddress)]
        public string AccountEmailAsLoginHash { get; set; }

        [DataType(DataType.Password)]
        public string AccountPasswordHash { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? LastModified { get; set; }

        public User AccountOfUser { get; set; }

        public int? AccountOfUserId { get; set; }

    }
}
