﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using System;
using System.Windows.Input;

namespace DeveloperNews.UI.ViewModels
{
    public class NewsItemViewModel : ViewModelBase
    {
        public NewsItemViewModel()
            => ClickCommand = new RelayCommand(ExecuteClick, () => !string.IsNullOrEmpty(Link));

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime Date { get; set; }

        public ICommand ClickCommand { get; set; }

        public string New { get; set; }

        private void ExecuteClick()
            => MessengerInstance.Send(new NotificationMessage<NewsItemViewModel>(this, Link));
    }
}