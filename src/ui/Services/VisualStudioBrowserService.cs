using System.Diagnostics;

namespace DeveloperNews.UI.Services
{
    using Core.Interfaces;

    public class VisualStudioBrowserService : IBrowserService
    {
        public void OpenUrl(string url, bool InternalBrowser = true)
        {
            Process.Start(url);
        }
    }
}