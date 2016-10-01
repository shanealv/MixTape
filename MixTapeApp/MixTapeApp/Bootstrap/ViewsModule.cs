using Autofac;
using MixTapeApp.Views;

namespace MixTapeApp.Bootstrap
{
    /// <summary>
    /// Autofac Module for registering Views
    /// </summary>
    class ViewsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>().AsSelf().SingleInstance();
        }
    }
}
