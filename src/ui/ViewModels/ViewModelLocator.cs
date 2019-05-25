using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace DeveloperNews.UI.ViewModels
{
    using Core.Interfaces;
    using Design;
    using DevNews;
    using Services;

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var container = SimpleIoc.Default;

            ServiceLocator.SetLocatorProvider(() => container);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                container.Register<IDataService, DesignDataService>();
            }
            else
            {
                container.Register<IDataService, RssDataService>();
            }

            container.Register<IBrowserService, VisualStudioBrowserService>();
            container.Register<DevNewsViewModel>();
        }
    }
}