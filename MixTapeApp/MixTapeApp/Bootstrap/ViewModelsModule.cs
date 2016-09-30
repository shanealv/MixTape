using Autofac;
using MixTapeApp.ViewModels;

namespace MixTapeApp.Bootstrap
{
    class ViewModelsModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
