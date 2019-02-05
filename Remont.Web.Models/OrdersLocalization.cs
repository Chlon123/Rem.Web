using Remont.Web.Models.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models
{
    public class OrdersLocalization : LocalizationAbstractBase
    {
        public int OrdersLocalizationId { get; set; }

        public virtual Order LocalizationOfOrder { get; set; }
        public int? LocalizationOfOrderId { get; set; }

    }
}
