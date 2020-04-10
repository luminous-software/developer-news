﻿using GalaSoft.MvvmLight;

using System.Windows.Input;

namespace DeveloperNews.UI.ViewModels
{
    public class CommandViewModel : ViewModelBase
    {
        private bool isVisible = true;
        private bool isEnabled;

        public string Name { get; set; }

        public ICommand Command { get; set; }

        public bool IsVisible
        {
            get => isVisible;
            set => Set(ref isVisible, value);
        }

        public bool IsEnabled
        {
            get => isEnabled;
            set => Set(ref isEnabled, value);
        }
    }
}