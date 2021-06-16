using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using WongaLibrary;
using WongaLibrary.Components;
using WongaLibrary.Utilities;

namespace ConsoleUIA
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
