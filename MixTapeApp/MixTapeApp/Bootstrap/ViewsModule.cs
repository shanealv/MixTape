using Autofac;
using MixTapeApp.Views;

namespace MixTapeApp.Bootstrap
{
    class ViewsModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>().AsSelf().SingleInstance();
        }
    }
}
