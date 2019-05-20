using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace DeveloperNews.UI.ViewModels.DevNews
{
    using Core.Interfaces;

    public class DevNewsViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private DevNewsItemViewModel selectedItem;
        private List<DevNewsItemViewModel> feedItems;

        //public void OnSelected(object sender, RoutedEventArgs e)
        //    => MessageBox.Show($"You clicked {SelectedItem.Title}");

        //private RelayCommand<SelectionChangedEventArgs> _selectedItemChanged;
        //public RelayCommand<SelectionChangedEventArgs> SelectedItemChanged
        //{
        //    get
        //    {
        //        if (_selectedItemChanged == null)
        //        {
        //            _selectedItemChanged = new RelayCommand<SelectionChangedEventArgs>((selectionChangedArgs) =>
        //            {
        //                // add a guard here to immediatelly return if you are modifying the original collection from code

        //            });
        //        }

        //        return _selectedItemChanged;
        //    }
        //}

        public RelayCommand RefreshCommand { get; private set; }
        public RelayCommand<string> ViewMoreCommand { get; private set; }

        public string DisplayName { get; internal set; }

        public string NewName { get; internal set; }

        public List<DevNewsItemViewModel> FeedItems
        {
            get => feedItems;
            set => Set(nameof(FeedItems), ref feedItems, value);
        }

        public DevNewsItemViewModel SelectedItem
        {
            get => selectedItem;
            set => Set(nameof(SelectedItem), ref selectedItem, value);
        }

        public string DevNewsUrl { get; internal set; }

        public int Count { get; internal set; }

        public string ViewMore { get; internal set; }

        public string ViewMoreUrl { get; internal set; }

        public DevNewsViewModel(IDataService dataService)
        {
            this.dataService = dataService;

            RefreshCommand = new RelayCommand(() => ExecuteRefresh(), CanExecuteRefresh);
            ViewMoreCommand = new RelayCommand<string>((link) => ExecuteViewMore(link), true);
        }

        public bool CanExecuteRefresh => true;

        public void ExecuteRefresh()
        {
            LoadItemsAsync();
        }

        public bool CanExecuteViewMore => true;

        public void ExecuteViewMore(string link)
        {
        }

        public async Task LoadItemsAsync()
        {
            var items = await dataService.GetItemsAsync(DevNewsUrl, Count);

            FeedItems =
            (
                from item in items
                select new DevNewsItemViewModel
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