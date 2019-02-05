using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models.AbstractClasses
{
    public abstract class OrderAbstractBase
    {
        public int OrderId { get; set; }

        public string OrderTitle { get; set; }

        public string OrderInfo { get; set; }

        public decimal OrderMinimalCost { get; set; }

        public decimal OrderMaximalCost { get; set; }
    }
}
