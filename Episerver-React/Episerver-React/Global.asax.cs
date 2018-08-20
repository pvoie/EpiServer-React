using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Episerver_React.App_Start;
using System.Collections.Generic;

namespace Episerver_React
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            PaginationConfig.PaginationRegister(PaginationConfig.Rules);
            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }
    }
}