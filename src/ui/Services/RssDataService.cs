using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeveloperNews.UI.Services
{
    using Core.Interfaces;
    using Core.Models;

    public class RssDataService : IDataService
    {
        public async Task<List<FeedItem>> GetItemsAsync(string url, int count)
        {
            //https://docs.microsoft.com/en-us/uwp/api/Windows.Web.Syndication.SyndicationClient

            //async Task GetFeedAsync(string feedUri)
            //{
            //    var uri = new Uri(feedUri);
            //    var client = new SyndicationClient()
            //    {
            //        BypassCacheOnRetrieve = true
            //    };
            //    currentFeed = await client.RetrieveFeedAsync(uri);
            //}

            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/9737ce16-044a-462d-99aa-d1b375a31232/how-to-develop-a-rss-feed-reader-in-wpf-application?forum=wpf
            //string feedUrl = "http://channel9.msdn.com/Feeds/RSS/";
            //System.Xml.XmlReader reader = System.Xml.XmlReader.Create(feedUrl);

            //System.ServiceModel.Syndication.SyndicationFeed feed = System.ServiceModel.Syndication.SyndicationFeed.Load(reader);

            //foreach (var item in feed.Items)
            //{
            //    // retrieve feed items here
            //}

            //https://wp.qmatteoq.com/?p=6486
            var client = new HttpClient();
            var result = await client.GetStringAsync(url);
            var xdoc = XDocument.Parse(result);

            return
            (
                from item in xdoc.Descendants("item").Take(count)
                select new FeedItem
                {
                    Title = (string)item.Element("title"),
                    Description = Regex.Replace((string)item.Element("description"), "<.*?>|&.*?;", string.Empty),
                    Link = (string)item.Element("link"),
                    PublishDate = DateTime.Parse((string)item.Element("pubDate"))
                }
            ).ToList();

            //Using SyndicationFeed:

            // var url = "http://fooblog.com/feed";
            // XmlReader reader = XmlReader.Create(url);
            // SyndicationFeed feed = SyndicationFeed.Load(reader);
            // reader.Close();
            // foreach (SyndicationItem item in feed.Items)
            // {
            //     String subject = item.Title.Text;
            //     String summary = item.Summary.Text;
            //     ...


            //https://blogs.msdn.microsoft.com/steveres/2008/01/20/using-syndicationfeed-to-display-photos-from-spaces-live-com/
            //using (WebClient client = new WebClient())

            //{

            //    //set your proxy to client here

            //    string data = client.DownloadString(url);

            //    using (XmlReader reader = XmlReader.Create(new StringReader(data)))

            //    {

            //        SyndicationFeed feed = SyndicationFeed.Load(reader);

            //        foreach (SyndicationItem item in feed.Items)

            //        {

            //            String subject = item.Title.Text;

            //            Console.WriteLine("{0}", subject);

            //        }

            //    }

            //}
        }
    }
}