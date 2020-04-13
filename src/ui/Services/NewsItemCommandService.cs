using GalaSoft.MvvmLight.Command;

using System;

namespace DeveloperNews.UI.Services
{
    using Interfaces;

    using Observables;

    using ViewModels;

    public class NewsItemCommandService : INewsItemCommandService
    {
        public ObservableCommandList GetCommands(Action refresh)
            => new ObservableCommandList
            {
                new CommandViewModel
                {
                    Name = "Refresh",
                    Command = new RelayCommand(refresh, true),
                }
            };
    }
}