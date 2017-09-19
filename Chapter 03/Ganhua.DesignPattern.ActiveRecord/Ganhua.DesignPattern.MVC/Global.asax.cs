using Castle.ActiveRecord.Framework;
using Ganhua.DesignPattern.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ganhua.DesignPattern.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IConfigurationSource source = ConfigurationManager.GetSection("activeRecord") as IConfigurationSource;
            Castle.ActiveRecord.ActiveRecordStarter.Initialize(source, typeof(Post), typeof(Comment));
        }
    }
}
