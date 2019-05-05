using System;

namespace DeveloperNews.UI.ViewModels
{
    internal class FeedItemViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
