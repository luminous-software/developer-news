using CommonServiceLocator;
using DeveloperNews.Core.Interfaces;
using DeveloperNews.UI.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace DeveloperNews.UI.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var ioc = SimpleIoc.Default;

            if (ViewModelBase.IsInDesignModeStatic)
            {
                //ioc.Register<IDataService, Design.RssDataService>();
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