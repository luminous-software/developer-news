using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

using Microsoft.VisualStudio.Shell;

using System.Collections.ObjectModel;

namespace DeveloperNews.UI.ViewModels
{
    using DeveloperNews.UI.Interfaces;

    using Observables;

    public class NewsControlViewModel : ViewModelBase
    {
        private const string DEV_NEWS_FEED_URL = "https://vsstartpage.blob.core.windows.net/news/vs";
        private const int Count = 0; //TODO: move to options

        private ObservableCollection<NewsItemViewModel> items = new ObservableCollection<NewsItemViewModel>();

        public NewsControlViewModel(INewsItemDataService dataService, INewsItemActionService actionService, INewsItemCommandService commandService) : base()
        {
            DataService = dataService;
            ActionService = actionService;
            CommandService = commandService;

            GetCommands();
            Refresh();

            MessengerInstance.Register<NotificationMessage<NewsItemViewModel>>(this,
                (message) => ActionService.DoAction(message.Content));
        }

        public ObservableCommandList Commands { get; set; }
        public INewsItemDataService DataService { get; }

        public INewsItemActionService ActionService { get; }

        public INewsItemCommandService CommandService { get; }

        public ObservableCollection<NewsItemViewModel> Items
        {
            get => items;
            set => Set(ref items, value);
        }

        private void GetCommands()
            => Commands = CommandService.GetCommands(/*MoreNews,*/ Refresh);

        private void MoreNews()
        { }

        public void Refresh()
             => ThreadHelper.JoinableTaskFactory.RunAsync(async ()
                 =>
                 {
                     Items.Clear();

                     return Items = await DataService.GetItemsAsync(DEV_NEWS_FEED_URL, Count);
                 });


    }
}