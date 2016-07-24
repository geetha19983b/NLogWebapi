using Elmah.Contrib.WebApi;
using NLogCustomerAPI.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace NLogCustomerAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());
            //config.Services.Add(typeof(IExceptionLogger), new NLogExceptionLogger());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
