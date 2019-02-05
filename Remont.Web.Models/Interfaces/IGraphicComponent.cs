using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models.Interfaces
{
    public interface IGraphicComponent
    {
        string GraphicComponentName { get; set; }

        byte GraphicComponentCode { get; set; }
    }
}
