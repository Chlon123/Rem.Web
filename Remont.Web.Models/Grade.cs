using Remont.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models
{
    public class Grade : IGraphicComponent
    {
        public int GradeId { get; set; }

        public string GraphicComponentName { get; set; }

        public byte GraphicComponentCode { get; set; }

        public virtual User GradeOfUser { get; set; }

        public int? GradeOfUserId { get; set; }
    }
}
