using Autofac;
using WongaLibrary;

namespace ConsoleUIB
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = LibraryContainerConfig.Configure();

            builder.RegisterType<Application>().As<IApplication>();

            return builder.Build();
        }
    }
}
