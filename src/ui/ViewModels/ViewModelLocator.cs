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
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var ioc = SimpleIoc.Default;

            if (ViewModelBase.IsInDesignModeStatic)
            {
                ioc.Register<IDataService, DesignDataService>();
            }
            else
            {
                ioc.Register<IDataService, RssDataService>();
            }

            ioc.Register<DeveloperNewsControlViewModel>();
            ioc.Register<StartPageTabViewModel>();
        }
    }
}