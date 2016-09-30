using Autofac;
using MixTapeApp.Services;

namespace MixTapeApp.Bootstrap
{
    class Bootstrapper
    {
        public void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterModule<ViewModelsModule>();
            builder.RegisterModule<ViewsModule>();
            var container = builder.Build();
            Resolver.SetContext(container);
        }
    }
}
