using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

using Microsoft.VisualStudio.Shell;

using System.Collections.ObjectModel;


namespace DeveloperNews.UI.ViewModels
{
    using DeveloperNews.UI.Interfaces;

    using Observables;

    using Options.Pages;

    using static DeveloperNews.Options.Constants.OptionsGuids;

    public class NewsItemsViewModel : ViewModelBase
    {
        private ObservableCollection<NewsItemViewModel> items = new ObservableCollection<NewsItemViewModel>();

        public NewsItemsViewModel(INewsItemDataService dataService, INewsItemActionService actionService, INewsItemCommandService commandService, IVisualStudioService visualStudioService)
        {
            DataService = dataService;
            ActionService = actionService;
            CommandService = commandService;
            VisualStudioService = visualStudioService;

            GetCommands();
            Refresh();

            MessengerInstance.Register<NotificationMessage<NewsItemViewModel>>(this,
                (message) => ActionService.DoAction(message.Content));
        }

        public INewsItemDataService DataService { get; }

        public INewsItemActionService ActionService { get; }

        public INewsItemCommandService CommandService { get; }

        public IVisualStudioService VisualStudioService { get; }

        public ObservableCollection<NewsItemViewModel> Items
        {
            get => items;
            set => Set(ref items, value);
        }

        public ObservableCommandList Commands { get; set; }

        private void GetCommands()
            => Commands = CommandService.GetCommands(Refresh, ShowOptions);

        public void Refresh()
             => ThreadHelper.JoinableTaskFactory.RunAsync(async ()
                 =>
                 {
                     var options = await GeneralOptions.GetLiveInstanceAsync();

                     if (options.ClearListBeforeRefresh)
                     {
                         Items.Clear();
                     }

                     return Items = await DataService.GetItemsAsync(options.FeedUrl, options.ItemsToDisplay);
                 });

        public void ShowOptions()
            => VisualStudioService.ShowToolsOptions(GeneralDialogPage);
    }
}