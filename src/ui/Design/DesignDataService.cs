using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DeveloperNews.UI.Design
{
    using Interfaces;

    using ViewModels;


    internal class DesignDataService : INewsItemDataService
    {
        public Task<ObservableCollection<NewsItemViewModel>> GetItemsAsync(string url, int count)
        {
            var items = new ObservableCollection<NewsItemViewModel>
            {
                new NewsItemViewModel
                {
                    Title = "Normal Title",
                    Description = "A normaldescription",
                    Link = "",
                    Date = DateTime.Now
                },
                new NewsItemViewModel
                {
                    Title = "A Very Long Title To Test The 'WrapWithOverFlow' Setting of the 'TitleStyle' Style",
                    Description = "A normaldescription",
                    Link = "",
                    Date = DateTime.Now
                }
            };

            return Task.FromResult(items);
        }

        public Task<ObservableCollection<NewsItemViewModel>> GetItemsAsync(string url)
            => throw new NotImplementedException();
    }
}