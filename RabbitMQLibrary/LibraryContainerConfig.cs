using Autofac;
using WongaLibrary.Components;
using WongaLibrary.Utilities;

namespace WongaLibrary
{
    public static class LibraryContainerConfig
    {
        public static ContainerBuilder Configure()
        {
            var builder = new ContainerBuilder();

            //Below can be changed to HarryPotterMessage class for a different script
            builder.RegisterType<StarWarsMessageHelper>().As<IMessageHelper>();
            builder.RegisterType<RabbitMqService>().As<IMessagerService>();
            builder.RegisterType<MessageLifeCycle>().As<IMessageLifeCycle>();

            return builder;
        }
    }
}
