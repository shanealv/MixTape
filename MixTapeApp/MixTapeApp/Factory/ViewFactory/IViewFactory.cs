using System;
using System.Windows;
using MixTapeApp.ViewModels;

namespace MixTapeApp.Factory
{
    interface IViewFactory
    {
        /// <summary>
        /// Registers the ViewModel and View relationship
        /// </summary>
        /// <typeparam name="TViewModel">a view model class</typeparam>
        /// <typeparam name="TView">a view class</typeparam>
        void Register<TViewModel, TView>()
            where TViewModel : IViewModel
            where TView : FrameworkElement;

        /// <summary>
        /// Creates the view associated with View Model type and assigns it's DataContext to the argument
        /// </summary>
        /// <typeparam name="TViewModel">a view model class</typeparam>
        /// <param name="viewModel">a view model object</param>
        FrameworkElement Resolve<TViewModel>(TViewModel viewModel) 
            where TViewModel : class, IViewModel;

        /// <summary>
        /// Creates a view model of the type argument and a view that is registered to its type.
        /// The generated view model's sate is set by the argument Action and set as the 
        /// DataContext of the generate view.
        /// </summary>
        /// <typeparam name="TViewModel">a view model class</typeparam>
        /// <param name="setStateAction">a set of actions to initialize the view model</param>
        /// <returns>a view</returns>
        FrameworkElement Resolve<TViewModel>(Action<TViewModel> setStateAction = null) 
            where TViewModel : class, IViewModel;

        /// <summary>
        /// Creates a view model of the type argument and a view that is registered to its type.
        /// The generated view model's sate is set by the argument Action and set as the 
        /// DataContext of the generate view.  The view model is returned in the out parameter.
        /// </summary>
        /// <typeparam name="TViewModel">a view model class</typeparam>
        /// <param name="viewModel">a view model variable to initialize</param>
        /// <param name="setStateAction">a set of actions to initialize the view model</param>
        /// <returns>a view</returns>
        FrameworkElement Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> setStateAction)
            where TViewModel : class, IViewModel;
    }
}