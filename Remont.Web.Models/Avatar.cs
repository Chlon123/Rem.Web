using Remont.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models
{
    public class Avatar : IGraphicComponent
    {
        public int AvatarId { get; set; }

        public string GraphicComponentName { get; set; }

        public byte GraphicComponentCode { get; set; }

        public virtual User AvatarOfUser { get; set; }

        public int? AvatarOfUserId { get; set; }
    }
}
