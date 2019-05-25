namespace DeveloperNews.Core.Interfaces
{
    public interface IBrowserService
    {
        void OpenUrl(string url, bool InternalBrowser = true);
    }
}