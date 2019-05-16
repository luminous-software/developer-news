using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace DeveloperNews.UI.ViewModels
{
    using Core.Interfaces;

    public class StartPageViewModel : ViewModelBase
    {
        private readonly IDataService dataService;

        public string DisplayName
            => "Start Page Items";

        public string NewName
            => "NEW ";

        public string Url { get; set; }

        public int Count { get; set; }

        public List<StartPageItemViewModel> FeedItems { get; set; }


        public StartPageViewModel(IDataService dataService)
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
                select new StartPageItemViewModel
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