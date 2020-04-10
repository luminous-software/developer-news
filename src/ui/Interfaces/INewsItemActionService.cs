
namespace DeveloperNews.UI.Interfaces
{
    using UI.ViewModels;

    public interface INewsItemActionService
    {
        void DoAction(NewsItemViewModel currentViewModel, bool internalBrowser = true);
    }
}