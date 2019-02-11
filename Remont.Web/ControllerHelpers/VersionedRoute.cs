using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;

namespace Remont.Web.ControllerHelpers
{
    /// <summary>
    /// Provides the route attribute that's restricted to a specific version of the api.
    /// </summary>

    internal class VersionedRoute : RouteFactoryAttribute
    {
        public int AllowedVersion { get; private set; }

        public VersionedRoute(string template, int allowedVersion)
            : base(template)
        {
            AllowedVersion = allowedVersion;
        }

        public override IDictionary<string, object> Constraints
        {
            get
            {
                var constraints = new HttpRouteValueDictionary();
                constraints.Add("Version", new VersionConstraint(AllowedVersion));
                return constraints;
            }
        }
    }
}