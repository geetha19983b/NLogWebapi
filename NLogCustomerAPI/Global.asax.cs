using Elmah.Contrib.WebApi;
using NLog.Contrib.LayoutRenderers;
using NLogCustomerAPI.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace NLogCustomerAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //initialize the NLog config
            NLog.Config.ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("mdlc", typeof(MdlcLayoutRenderer));

            GlobalConfiguration.Configure(configuration =>
            {
                //add the custom handler to the message handler pipeline
                configuration.MessageHandlers.Add(new LoggerDelegatingHandler());

                WebApiConfig.Register(configuration);
            });
            GlobalConfiguration.Configuration.Filters.Add(new ElmahHandleErrorApiAttribute());
        }
    }
}
