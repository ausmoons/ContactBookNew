﻿using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Optimization;
using System.Web.Routing;

namespace ContactBook
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);




        }
    }
}
