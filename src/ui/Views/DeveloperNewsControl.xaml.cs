using System.Windows.Controls;
using Microsoft.VisualStudio.Shell;

namespace DeveloperNews.UI.Views
{
    using System;
    using GalaSoft.MvvmLight.Ioc;
    using ViewModels;

    public partial class DeveloperNewsControl : UserControl
    {
        public DeveloperNewsControlViewModel DeveloperNewsControlViewModel { get; }

        public StartPageViewModel StartPageViewModel { get; set; }

        public DeveloperNewsControl()
        {
            InitializeComponent();

            var container = SimpleIoc.Default;

            DeveloperNewsControlViewModel = container.GetInstance<DeveloperNewsControlViewModel>();
            DataContext = DeveloperNewsControlViewModel;

            StartPageViewModel = container.GetInstance<StartPageViewModel>();
            StartPageFeedItems.DataContext = StartPageViewModel;
            StartPageViewModel.Url = "https://devblogs.microsoft.com/visualstudio/feed/";  //TODO: move StartPageTabViewModel.Url to options
            StartPageViewModel.Count = 11;  //TODO: move StartPageTabViewModel.Count to options

            ThreadHelper.JoinableTaskFactory.Run(async delegate
            {
                await StartPageViewModel.LoadItemsAsync();
            });
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }
    }
}