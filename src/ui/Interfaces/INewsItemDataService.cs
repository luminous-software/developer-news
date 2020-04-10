using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace DeveloperNews.UI.Interfaces
{

    using ViewModels;

    public interface INewsItemDataService
    {
        Task<ObservableCollection<NewsItemViewModel>> GetItemsAsync(string url, int Count);
    }
}