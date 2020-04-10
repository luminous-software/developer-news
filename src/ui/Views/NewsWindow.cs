using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell;

using System;
using System.Runtime.InteropServices;

namespace DeveloperNews.UI.Views.DevNews
{
    using static UI.Constants.Guids;

    [Guid(DeveloperNewsPaneGuidString)]
    public class DeveloperNewsWindow : ToolWindowPane
    {
        public DeveloperNewsWindow() : base(null)
        {
            Caption = "Developer News";
            BitmapImageMoniker = KnownMonikers.ConditionalRuleIfThen;
            Content = new NewsControl();
        }
    }
}