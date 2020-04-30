using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WeightLossSystem.BL.Infrastructure;
using WeightLossSystem.BL.Services;
using WeightLossSystem.Domain.EF;
using WeightLossSystem.WebUI.Infrastructure.Binders;
using WeightLossSystem.WebUI.Util;

namespace WeightLossSystem.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(CartService), new CartModelBinder());


            Database.SetInitializer(new ContextDataInitializer());
            NinjectModule serviceModuleWebUI = new ServiceModuleWebUI();
            NinjectModule serviceModuleBL = new ServiceModule("ConnectionString");
            var kernel = new StandardKernel(serviceModuleBL, serviceModuleWebUI);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
