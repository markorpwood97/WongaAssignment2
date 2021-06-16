using Autofac;
using ConsoleUIB;
using System;
using WongaLibrary;
//using WongaLibrary.Components;

namespace ConsoleUIB
{
    class Program
    {
        static void Main()
        {
            var containerBuilder = ContainerConfig.Configure();

            using (var scope = containerBuilder.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
