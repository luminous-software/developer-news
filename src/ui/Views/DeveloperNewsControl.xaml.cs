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

        public DevNewsViewModel DevNewsViewModel { get; set; }

        public DeveloperNewsControl()
        {
            InitializeComponent();

            var container = SimpleIoc.Default;

            //DeveloperNewsControlViewModel = container.GetInstance<DeveloperNewsControlViewModel>();
            DevNewsViewModel = container.GetInstance<DevNewsViewModel>();
            DataContext = DevNewsViewModel;

            DevNewsViewModel.DisplayName = "Dev News";
            DevNewsViewModel.NewName = "NEW ";
            DevNewsViewModel.DevNewsUrl = "https://vsstartpage.blob.core.windows.net/news/vs";  //TODO: move DevNewsViewModel.Url to options // https://devblogs.microsoft.com/visualstudio/feed/
            DevNewsViewModel.Count = 7;  //TODO: move DevNewsViewModel.Count to options
            DevNewsViewModel.ViewMore = "View More News";
            DevNewsViewModel.ViewMoreUrl = "https://devblogs.microsoft.com/visualstudio/";

            ThreadHelper.JoinableTaskFactory.Run(async delegate
            {
                await DevNewsViewModel.LoadItemsAsync();
            });
        }

        protected override void OnInitialized(EventArgs e)
            => base.OnInitialized(e);
    }
}