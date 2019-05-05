using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperNews.Core.Interfaces
{
    using Models;

    public interface IRssFeedService
    {
        Task<List<StartPageFeedItem>> GetStartPageFeedItemsAsync(string url, int count);
    }
}