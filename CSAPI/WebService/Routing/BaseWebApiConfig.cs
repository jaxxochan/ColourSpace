using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace CSAPI.WebService.Routing
{
    public abstract class BaseWebApiConfig
    {
        protected static void BuidShortRoute(HttpRouteCollection routes, string routeName, string routeUrl, Type controllerType)
        {
            routes.MapHttpRoute(routeName, BuildRoute(routeUrl),
                new
                {
                    Controller = controllerType.Name.Remove(controllerType.Name.Length - DefaultHttpControllerSelector.ControllerSuffix.Length)
                });
        }

        protected static string BuildRoute(string routeTemplateName)
        {
            return "" + routeTemplateName;
        }
    }
}