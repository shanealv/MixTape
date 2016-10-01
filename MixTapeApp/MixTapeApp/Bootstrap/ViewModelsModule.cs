using Autofac;
using MixTapeApp.ViewModels;

namespace MixTapeApp.Bootstrap
{
    /// <summary>
    /// Autofac Module for registering View Models
    /// </summary>
    class ViewModelsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
