using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell;

using System;
using System.Runtime.InteropServices;

namespace DeveloperNews.UI.Views.DevNews
{
    using static UI.Constants.Guids;

    [Guid(DeveloperNewsPaneGuidString)]
    public class NewsItemsWindow : ToolWindowPane
    {
        public NewsItemsWindow() : base(null)
        {
            Caption = Vsix.Name;
            BitmapImageMoniker = KnownMonikers.ConditionalRuleIfThen;
            Content = new NewsItemsView();
        }
    }
}