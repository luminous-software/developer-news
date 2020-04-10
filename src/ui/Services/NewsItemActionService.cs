﻿namespace DeveloperNews.UI.Services
{
    using Core.Interfaces;
    using Interfaces;
    using ViewModels;

    public class NewsItemActionService : INewsItemActionService
    {
        public NewsItemActionService(IVisualStudioService vsService)
            => VisualStudioService = vsService;

        public IVisualStudioService VisualStudioService { get; }

        public void DoAction(NewsItemViewModel currentViewModel, bool internalBrowser = true)
        {
            var url = currentViewModel.Link;

            VisualStudioService.OpenWebPage(url, internalBrowser);
        }
    }
}
