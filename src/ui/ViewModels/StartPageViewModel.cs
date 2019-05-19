using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace DeveloperNews.UI.ViewModels
{
    using System.Windows;
    using System.Windows.Controls;
    using Core.Interfaces;
    using GalaSoft.MvvmLight.CommandWpf;

    public class StartPageViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private StartPageItemViewModel selectedItem;
        private List<StartPageItemViewModel> feedItems;

        //public void OnSelected(object sender, RoutedEventArgs e)
        //    => MessageBox.Show($"You clicked {SelectedItem.Title}");

        public RelayCommand<string> ViewMoreCommand { get; set; }

        private RelayCommand<SelectionChangedEventArgs> _selectedItemChanged;
        public RelayCommand<SelectionChangedEventArgs> SelectedItemChanged
        {
            get
            {
                if (_selectedItemChanged == null)
                {
                    _selectedItemChanged = new RelayCommand<SelectionChangedEventArgs>((selectionChangedArgs) =>
                    {
                        // add a guard here to immediatelly return if you are modifying the original collection from code

                    });
                }

                return _selectedItemChanged;
            }
        }

        public string DisplayName { get; set; }

        public string NewName { get; set; }

        public List<StartPageItemViewModel> FeedItems
        {
            get => feedItems;

            set => Set(nameof(FeedItems), ref feedItems, value);
        }

        public StartPageItemViewModel SelectedItem
        {
            get => selectedItem;

            set => Set(nameof(SelectedItem), ref selectedItem, value);
        }

        public string StartPageUrl { get; set; }

        public int Count { get; set; }

        public string ViewMore { get; internal set; }

        public string ViewMoreUrl { get; internal set; }

        public StartPageViewModel(IDataService dataService)
        {
            this.dataService = dataService;

            ViewMoreCommand = new RelayCommand<string>((link) => MessageBox.Show(link), true);
        }

        public async Task LoadItemsAsync()
        {
            var items = await dataService.GetItemsAsync(StartPageUrl, Count);

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