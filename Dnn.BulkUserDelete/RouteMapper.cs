using System;
using DotNetNuke.Web.Api;

namespace Dnn.Modules.BulkUserDelete
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("Dnn_BulkUserDelete", "default", "{controller}/{action}", new[] {"Dnn.Modules.BulkUserDelete"});
        }
    }
}
