using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Dashboard.Models;
using FakeDbSet;
using Moq;

namespace Dashboard
{
    /// <summary>
    /// Wires up Autofac
    /// </summary>
    public static class ContainerConfig
    {
        public static IContainer BuildContainer()
        {
            // no database? no problem!

            var klaus = new Gutachter { Id = 2, Vorname = "Klaus" };
            klaus.Gutachten.Add(new Gutachten());

            var inMemoryDbSet = new InMemoryDbSet<Gutachter>(true)
                             {
                                 new Gutachter { Id = 1, Vorname = "Hans In Memory" },
                                 new Gutachter { Id = 2, Vorname = "Horst" },
                                 new Gutachter { Id = 3, Vorname = "Inge" }
                             };

            var mockedContext = new Mock<IDashboardContext>();
            mockedContext.Setup(x => x.Gutachter).Returns(inMemoryDbSet);

            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<DashboardContext>()
            //        .As<IDashboardContext>()
            //        .InstancePerRequest();


            builder.RegisterInstance(mockedContext.Object)
                .As<IDashboardContext>();

            builder.RegisterType<GutachterRepository>()
                .As<IGutachterRepository>()
                .InstancePerRequest();

            return builder.Build();
        }
    }
}