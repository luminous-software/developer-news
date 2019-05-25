using System.Collections.Generic;

namespace DeveloperNews.UI.Design
{
    using Core.Interfaces;
    using Core.Models;
    using System;
    using System.Threading.Tasks;

    internal class DesignDataService : IDataService
    {
        public Task<List<FeedItem>> GetItemsAsync(string url, int count)
        {
            var items = new List<FeedItem>
            {
                new FeedItem
                {
                    Title = "Normal Title",
                    Description = "A normaldescription",
                    Link = "",
                    PublishDate = DateTime.Now
                },
                new FeedItem
                {
                    Title = "A Very Long Title To Test The 'WrapWithOverFlow' Setting of the 'TitleStyle' Style",
                    Description = "A normaldescription",
                    Link = "",
                    PublishDate = DateTime.Now
                }
            };

            return Task.FromResult(items);
        }
    }
}