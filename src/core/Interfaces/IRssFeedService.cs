using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperNews.Core.Interfaces
{
    using Models;

    public interface IRssFeedService
    {
        Task<List<FeedItem>> GetFeedItemsAsync(string url);
    }
}