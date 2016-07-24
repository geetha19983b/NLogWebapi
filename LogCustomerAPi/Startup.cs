using log4net;
using log4net.Config;
using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LogCustomerAPi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            // register log4net
            XmlConfigurator.Configure();

            // register routes 
            WebApiConfig.Register(config);

            // registering container 
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            config.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            // configure log4net variables
            GlobalContext.Properties["processId"] = "LoggerSimple";
            config.RegisterFilters(container);
            config.RegisterGlobalExceptionHandler(container);
            app.UseWebApi(config);
        }
    }
}