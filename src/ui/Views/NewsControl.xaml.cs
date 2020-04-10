using GalaSoft.MvvmLight.Ioc;

using Microsoft.VisualStudio.Shell;

using System;
using System.Windows.Controls;

namespace DeveloperNews.UI.Views
{
    using ViewModels;

    public partial class NewsControl : UserControl
    {
        //public DeveloperNewsControlViewModel DeveloperNewsControlViewModel { get; }

        public NewsItemsViewModel NewsViewModel { get; set; }

        public NewsControl()
        {
            InitializeComponent();

            var container = SimpleIoc.Default;

            //DeveloperNewsControlViewModel = container.GetInstance<DeveloperNewsControlViewModel>();
            NewsViewModel = container.GetInstance<NewsItemsViewModel>();
            DataContext = NewsViewModel;

            NewsViewModel.DisplayName = "Dev News";
            NewsViewModel.NewName = "NEW ";
            NewsViewModel.DevNewsUrl = "https://vsstartpage.blob.core.windows.net/news/vs";  //TODO: move DevNewsViewModel.Url to options // https://devblogs.microsoft.com/visualstudio/feed/
            NewsViewModel.Count = 7;  //TODO: move DevNewsViewModel.Count to options
            NewsViewModel.ViewMore = "View More News";
            NewsViewModel.ViewMoreUrl = "https://devblogs.microsoft.com/visualstudio/";

            ThreadHelper.JoinableTaskFactory.Run(async delegate
            {
                await NewsViewModel.LoadItemsAsync();
            });
        }

        protected override void OnInitialized(EventArgs e)
            => base.OnInitialized(e);
    }
}