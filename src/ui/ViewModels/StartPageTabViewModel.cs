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

        public string DisplayName
            => "Start Page Feed";

        public string NewName
            => "NEW ";

        public string Url { get; set; }

        public int Count { get; set; }

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