using Ganhua.DesignPattern.Model;
using Ganhua.DesignPattern.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Ganhua.DesignPattern.WebUI
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var container = new UnityContainer();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<Service.ProductService>();
            Application["container"] = container;
        }
    }
}