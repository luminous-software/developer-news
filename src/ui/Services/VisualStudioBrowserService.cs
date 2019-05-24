using System.Diagnostics;
using System.Windows;
using Luminous.Code.VisualStudio.Packages;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace DeveloperNews.UI.Services
{
    using Core.Interfaces;

    public class VisualStudioBrowserService : IBrowserService
    {
        private const uint navigation = (uint)__VSWBNAVIGATEFLAGS.VSNWB_ForceNew;

        private IVsWebBrowsingService browsingService;
        private ProcessStartInfo startInfo;

        private IVsWebBrowsingService BrowsingService
            => browsingService ?? (browsingService = AsyncPackageBase.GetGlobalService<SVsWebBrowsingService, IVsWebBrowsingService>());

        private ProcessStartInfo StartInfo
            => startInfo ?? (startInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                Verb = "Open"
            });

        public VisualStudioBrowserService()
        { }

        public void OpenUrl(string url, bool internalBrowser = true)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                if (internalBrowser == true)
                {
                    BrowsingService.Navigate(url, navigation, out var ppFrame);
                }
                else
                {
                    StartInfo.FileName = url;
                    Process.Start(StartInfo);
                }
            }
            catch
            {
                MessageBox.Show("Cannot launch this url.", "Extension Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}