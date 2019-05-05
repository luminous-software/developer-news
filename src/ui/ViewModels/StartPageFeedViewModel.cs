using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperNews.UI.ViewModels
{
    using Services;
    using System.Linq;

    internal class StartPageFeedViewModel
    {
        private List<StartPageFeedItemViewModel> _items;
        private readonly string _url = "https://devblogs.microsoft.com/visualstudio/feed/"; //TODO: move this to options

        public List<StartPageFeedItemViewModel> FeedItems { get; set; }

        public async Task LoadItemsAsync()
        {
            var items = await new RssFeedService().GetStartPageFeedItemsAsync(_url, 10);

            _items =
            (
                from item in items
                select new StartPageFeedItemViewModel
                {
                    Title = item.Title,
                    Description = item.Description,
                    Link = item.Link,
                    PublishDate = item.PublishDate
                }
            ).ToList();
        }
    }
}