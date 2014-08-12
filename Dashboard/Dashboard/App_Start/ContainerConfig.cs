using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Dashboard.Models;

namespace Dashboard
{
    /// <summary>
    /// Wires up Autofac
    /// </summary>
    public static class ContainerConfig
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DashboardContext>()
                    .As<IDashboardContext>()
                    .InstancePerRequest();

            builder.RegisterType<GutachterRepository>()
                .As<IGutachterRepository>()
                .InstancePerRequest();

            return builder.Build();
        }
    }
}