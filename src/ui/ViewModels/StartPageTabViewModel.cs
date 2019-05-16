using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace DeveloperNews.UI.ViewModels
{
    using Core.Interfaces;

    public class StartPageTabViewModel : ViewModelBase
    {
        private readonly IDataService dataService;

        public string DisplayName
            => "Start Page Feed";

        public string NewName
            => "NEW ";

        public string Url { get; set; }

        public int Count { get; set; }

        public List<StartPageListItemViewModel> FeedItems { get; set; }


        public StartPageTabViewModel(IDataService dataService)
        {
            this.dataService = dataService;
            //RefreshCommand = new RefreshCommand((link) => MessageBox.Show(link), () => true);
        }

        public async Task LoadItemsAsync()
        {
            var items = await dataService.GetItemsAsync(Url, Count);

            FeedItems =
            (
                from item in items
                select new StartPageListItemViewModel
                {
                    Title = item.Title,
                    Description = item.Description,
                    Link = item.Link,
                    New = NewName,
                    PublishDate = item.PublishDate
                }
            ).ToList();
        }
    }
}