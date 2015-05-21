using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Autofac;
using Autofac.Integration.Mvc;

using OSharp.Core;
using OSharp.Core.Data;
using OSharp.Core.Data.Entity;
using OSharp.Demo.Dtos;
using OSharp.Demo.Web.Logging;
using OSharp.Utility.Logging;


namespace OSharp.Demo.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            RoutesRegister();
            DtoMappers.MapperRegister();
            AutofacMvcRegister();
            DatabaseInitialize();
            LoggingInitialize();
        }

        private static void RoutesRegister()
        {
            RouteCollection routes = RouteTable.Routes;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "OSharp.Demo.Web.Controllers" });
        }

        private static void AutofacMvcRegister()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>));
            Type baseType = typeof(IDependency);
            string path = AppDomain.CurrentDomain.RelativeSearchPath;
            Assembly[] assemblies = Directory.GetFiles(path, "*.dll").Select(m => Assembly.LoadFrom(m)).ToArray();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                .AsSelf()   //自身服务，用于没有接口的类
                .AsImplementedInterfaces()  //接口服务
                .PropertiesAutowired()  //属性注入
                .InstancePerLifetimeScope();    //保证生命周期基于请求

            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void DatabaseInitialize()
        {
            string file = HttpContext.Current.Server.MapPath("bin/OSharp.Demo.Services.dll");
            Assembly assembly = Assembly.LoadFrom(file);
            DatabaseInitializer.AddMapperAssembly(assembly);
            DatabaseInitializer.Initialize();
        }

        private static void LoggingInitialize()
        {
            Log4NetLoggerAdapter adapter = new Log4NetLoggerAdapter();
            LogManager.AddLoggerAdapter(adapter);
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }
    }
}