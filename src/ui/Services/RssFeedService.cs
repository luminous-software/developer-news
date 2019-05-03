using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeveloperNews.UI.Services
{
    using Core.Interfaces;
    using Core.Models;

    public class RssFeedService : IRssFeedService
    {
        public async Task<List<FeedItem>> GetFeedItemsAsync(string url)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(url);
            var xdoc = XDocument.Parse(result);

            return
            (
                from item in xdoc.Descendants("item")
                select new FeedItem
                {
                    Title = (string)item.Element("title"),
                    Description = (string)item.Element("description"),
                    Link = (string)item.Element("link"),
                    PublishDate = DateTime.Parse((string)item.Element("pubDate"))
                }
            ).ToList();
        }
    }
}