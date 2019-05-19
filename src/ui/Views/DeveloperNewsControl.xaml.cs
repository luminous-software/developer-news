using System.Windows.Controls;
using Microsoft.VisualStudio.Shell;

namespace DeveloperNews.UI.Views
{
    using System;
    using GalaSoft.MvvmLight.Ioc;
    using ViewModels;

    public partial class DeveloperNewsControl : UserControl
    {
        //public DeveloperNewsControlViewModel DeveloperNewsControlViewModel { get; }

        public StartPageViewModel StartPageViewModel { get; set; }

        public DeveloperNewsControl()
        {
            InitializeComponent();

            var container = SimpleIoc.Default;

            //DeveloperNewsControlViewModel = container.GetInstance<DeveloperNewsControlViewModel>();
            StartPageViewModel = container.GetInstance<StartPageViewModel>();
            DataContext = StartPageViewModel;

            StartPageViewModel.DisplayName = "Dev News";
            StartPageViewModel.NewName = "NEW ";
            StartPageViewModel.StartPageUrl = "https://vsstartpage.blob.core.windows.net/news/vs";  //TODO: move StartPageTabViewModel.Url to options // https://devblogs.microsoft.com/visualstudio/feed/
            StartPageViewModel.Count = 7;  //TODO: move StartPageTabViewModel.Count to options
            StartPageViewModel.ViewMore = "View More News";
            StartPageViewModel.ViewMoreUrl = "https://devblogs.microsoft.com/visualstudio/";

            ThreadHelper.JoinableTaskFactory.Run(async delegate
            {
                await StartPageViewModel.LoadItemsAsync();
            });
        }

        protected override void OnInitialized(EventArgs e)
            => base.OnInitialized(e);
    }
}