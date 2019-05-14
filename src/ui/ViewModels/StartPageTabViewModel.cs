using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperNews.UI.ViewModels
{
    using Core.Interfaces;
    //using Commands;

    public class StartPageTabViewModel : ViewModelBase
    {
        private readonly IDataService dataService;

        public string TabName
            => "Start Page Feed";

        public string StartPageFeedUrl
            => "https://devblogs.microsoft.com/visualstudio/feed/";  //TODO: move to options

        public List<StartPageListItemViewModel> FeedItems { get; set; }

        public RelayCommand<string> ClickCommand { get; private set; }

        public StartPageTabViewModel(IDataService dataService)
        {
            this.dataService = dataService;
            //ClickCommand = new ClickCommand((link) => MessageBox.Show(link), CanExecute());
        }

        //private void Execute(string link)
        //    => MessageBox.Show(link);

        //private bool CanExecute()
        //    => true;

        public async Task LoadItemsAsync()
        {
            var items = await dataService.GetItemsAsync(StartPageFeedUrl, 100);

            FeedItems =
            (
                from item in items
                select new StartPageListItemViewModel
                {
                    Title = item.Title,
                    Description = item.Description,
                    Link = item.Link,
                    New = "NEW ",
                    PublishDate = item.PublishDate
                }
            ).ToList();
        }
    }
}