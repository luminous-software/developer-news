using CommonServiceLocator;

using GalaSoft.MvvmLight.Ioc;

namespace DeveloperNews.UI.ViewModels
{

    using Interfaces;

    using Services;

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var container = SimpleIoc.Default;

            ServiceLocator.SetLocatorProvider(() => container);


            RegisterServices(container);
            RegisterViewModels(container);
        }

        public static NewsItemsViewModel NewsItemsViewModel
           => ServiceLocator.Current.GetInstance<NewsItemsViewModel>();

        private void RegisterServices(SimpleIoc container)
        {
            container.Register<IDialogService, DialogService>();
            container.Register<IVisualStudioService, VisualStudioService>();

            container.Register<IDateTimeService, DateTimeService>();

            container.Register<INewsItemDataService, NewsItemDataService>();
            container.Register<INewsItemActionService, NewsItemActionService>();
            container.Register<INewsItemCommandService, NewsItemCommandService>();
        }

        private void RegisterViewModels(SimpleIoc container)
            => container.Register<NewsItemsViewModel>();
    }
}