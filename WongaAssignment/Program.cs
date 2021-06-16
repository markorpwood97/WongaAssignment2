using Autofac;
using ConsoleUIA;
using System;
using WongaLibrary.Components;

namespace WongaAssignment
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
