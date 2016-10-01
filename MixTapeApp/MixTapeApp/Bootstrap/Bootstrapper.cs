using Autofac;
using MixTapeApp.Factory;
using MixTapeApp.Services;
using MixTapeApp.ViewModels;
using MixTapeApp.Views;

namespace MixTapeApp.Bootstrap
{
    /// <summary>
    /// Utility class for initializing the Autofac Dependency environment
    /// </summary>
    class Bootstrapper
    {
        /// <summary>
        /// Builds the dependency injection container as forwards it to Resolver
        /// </summary>
        public void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterModule<ViewModelsModule>();
            builder.RegisterModule<ViewsModule>();
            builder.RegisterType<ViewFactory>().AsImplementedInterfaces().SingleInstance();

            var container = builder.Build();
            RegisterViews(container);
            Resolver.SetContext(container);
        }

        /// <summary>
        /// Initializes the viewmodel to view mappings
        /// </summary>
        /// <param name="container">the dependency injeciton container</param>
        private void RegisterViews(IContainer container)
        {
            var factory = container.Resolve<IViewFactory>();
            factory.Register<MainViewModel, MainWindow>();
        }
    }
}
