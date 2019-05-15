using Microsoft.VisualStudio.Shell;
using System.Windows.Controls;

namespace DeveloperNews.UI.Views
{
    using GalaSoft.MvvmLight.Ioc;
    using System;
    using ViewModels;

    public partial class DeveloperNewsControl : UserControl
    {
        public DeveloperNewsControlViewModel DeveloperNewsControlViewModel { get; }

        public StartPageTabViewModel StartPageTabViewModel { get; set; }

        public DeveloperNewsControl()
        {
            InitializeComponent();

            var container = SimpleIoc.Default;

            DeveloperNewsControlViewModel = container.GetInstance<DeveloperNewsControlViewModel>();
            DataContext = DeveloperNewsControlViewModel;

            StartPageTabViewModel = container.GetInstance<StartPageTabViewModel>();
            StartPageTab.DataContext = StartPageTabViewModel;
            StartPageTabViewModel.Url = "https://devblogs.microsoft.com/visualstudio/feed/";  //TODO: move StartPageTabViewModel.Url to options
            StartPageTabViewModel.Count = 11;  //TODO: move StartPageTabViewModel.Count to options

            ThreadHelper.JoinableTaskFactory.Run(async delegate
            {
                await StartPageTabViewModel.LoadItemsAsync();
            });
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }
    }
}