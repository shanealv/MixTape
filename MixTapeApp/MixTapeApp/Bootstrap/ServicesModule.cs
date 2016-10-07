using Autofac;
using MixTapeApp.Services;

namespace MixTapeApp.Bootstrap
{
    /// <summary>
    /// Autofac Module for registering services
    /// </summary>
    class ServicesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DummyService>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
