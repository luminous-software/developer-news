using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace DeveloperNews.UI.ViewModels
{
    using Core.Interfaces;
    using Design;
    using Services;

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var ioc = SimpleIoc.Default;

            ServiceLocator.SetLocatorProvider(() => ioc);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                ioc.Register<IDataService, DesignDataService>();
            }
            else
            {
                ioc.Register<IDataService, RssDataService>();
            }

            ioc.Register<DevNewsViewModel>();
        }
    }
}