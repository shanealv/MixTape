using Autofac;
using MixTapeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MixTapeApp.Factory
{
    class ViewFactory : IViewFactory
    {
        private IDictionary<Type, Type> TypeMap { get; } = new Dictionary<Type, Type>();
        private IComponentContext _componentContext { get; }

        public ViewFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void Register<TViewModel, TView>()
            where TViewModel : IViewModel
            where TView : FrameworkElement
        {
            TypeMap[typeof(TViewModel)] = typeof(TView);
        }

        public FrameworkElement Resolve<TViewModel>(TViewModel viewModel)
            where TViewModel : class, IViewModel
        {
            var viewType = TypeMap[typeof(TViewModel)];
            var view = _componentContext.Resolve(viewType) as FrameworkElement;
            view.DataContext = viewModel;
            return view;
        }

        public FrameworkElement Resolve<TViewModel>(Action<TViewModel> setStateAction = null)
            where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            return Resolve(out viewModel, setStateAction);
        }

        public FrameworkElement Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> setStateAction) 
            where TViewModel : class, IViewModel
        {
            viewModel = _componentContext.Resolve<TViewModel>();

            var viewType = TypeMap[typeof(TViewModel)];
            var view = _componentContext.Resolve(viewType) as FrameworkElement;

            if (setStateAction != null)
                viewModel.SetState(setStateAction);

            view.DataContext = viewModel;
            return view;
        }
    }
}
