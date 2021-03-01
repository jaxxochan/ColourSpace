using Autofac;
using Autofac.Integration.WebApi;
using CS.Api.DI;
using CS.Api.Facade.CustomAuthentication;
using log4net;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using static CS.Api.Facade.Models.Home.Home;
using Autofac.Integration.Mvc;

namespace CSAPI
{
    public class MvcApplication : HttpApplication
    {
        private readonly ILog profilerLog = LogManager.GetLogger("ProfilingLogger");
        private IContainer container;

        protected void Application_Start()
        {
            InitializeLog4Net();

            var clock = new Stopwatch();
            profilerLog.InfoFormat("Application Starting");
            clock.Start();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly()); //Register MVC Controllers

            var cSDIModule = new CSDIModule();
            builder.RegisterModule(cSDIModule);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers
            container = builder.Build();

            //Setting the dependency resolver for Web API.
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //Setting the dependency resolver for MVC.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            clock.Stop();
            profilerLog.InfoFormat("Application Started, after {0}ms", clock.ElapsedMilliseconds);
        }

        private void InitializeLog4Net()
        {
            var log4NetConfigPath = AppDomain.CurrentDomain.BaseDirectory + @"Configuration\log4net.config";
            if (!File.Exists(log4NetConfigPath))
            {
                throw new Exception("CS : Log4net Config file not found at :" + log4NetConfigPath);
            }
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies["cs_cookie"];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                var serializeModel = JsonConvert.DeserializeObject<CustomSerializeModel>(authTicket.UserData);

                CustomPrincipal principal = new CustomPrincipal(authTicket.Name);

                principal.UserId = serializeModel.UserId;
                principal.FirstName = serializeModel.FirstName;
                principal.LastName = serializeModel.LastName;
                principal.RoleId = serializeModel.RoleId;
                principal.RoleName = serializeModel.RoleName;

                HttpContext.Current.User = principal;
            }
        }
    }
}