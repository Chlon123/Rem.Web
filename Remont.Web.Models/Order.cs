using Remont.Web.Models.AbstractClasses;
using Remont.Web.Models.Interfaces;
using Remont.Web.Models.ModelEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models
{
    public class Order : OrderAbstractBase, IModificationHistory
    {
        public SpecializationEnum OrderSpecialization { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? LastModified { get; set; }

        public virtual ICollection<OrdersLocalization> OrdersLocalization { get; set; }

        public virtual ICollection<User> OrdersOfUser { get; set; }

    }
}
