using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
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
using OSharp.Demo.Web.Dtos;


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
            Assembly[] assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                .Select(Assembly.Load).ToArray();
            assemblies = assemblies.Union(new[] { Assembly.GetExecutingAssembly() }).ToArray();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                .AsImplementedInterfaces().InstancePerLifetimeScope();//InstancePerLifetimeScope 保证生命周期基于请求

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void DatabaseInitialize()
        {
            DatabaseInitializer.Initialize();

            Assembly assembly = Assembly.GetExecutingAssembly();
            DatabaseInitializer.AddMapperAssembly(assembly);

            //EF预热
            using (CodeFirstDbContext context = new CodeFirstDbContext())
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                StorageMappingItemCollection mappingItemCollection = (StorageMappingItemCollection)objectContext.ObjectStateManager
                    .MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingItemCollection.GenerateViews(new List<EdmSchemaError>());
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }
    }
}