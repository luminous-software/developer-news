﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

using Microsoft.VisualStudio.Shell;

using System.Collections.ObjectModel;


namespace DeveloperNews.UI.ViewModels
{
    using Interfaces;

    using Observables;

    using Options.Pages;

    public class NewsItemsViewModel : ViewModelBase
    {
        private ObservableCollection<NewsItemViewModel> items = new ObservableCollection<NewsItemViewModel>();

        public NewsItemsViewModel(INewsItemDataService dataService, INewsItemActionService actionService, INewsItemCommandService commandService)
        {
            DataService = dataService;
            ActionService = actionService;
            CommandService = commandService;

            GetCommands();
            Refresh();

            MessengerInstance.Register<NotificationMessage<NewsItemViewModel>>(this,
                (message) => ActionService.DoAction(message.Content));
        }

        public INewsItemDataService DataService { get; }

        public INewsItemActionService ActionService { get; }

        public INewsItemCommandService CommandService { get; }

        public ObservableCollection<NewsItemViewModel> Items
        {
            get => items;
            set => Set(ref items, value);
        }

        public ObservableCommandList Commands { get; set; }

        private void GetCommands()
            => Commands = CommandService.GetCommands(Refresh);

        public void Refresh()
             => ThreadHelper.JoinableTaskFactory.RunAsync(async ()
                 =>
                 {
                     Items.Clear();

                     var options = await GeneralOptions.GetLiveInstanceAsync();

                     return Items = await DataService.GetItemsAsync(options.FeedUrl, options.ItemsToDisplay);
                 });
    }
}