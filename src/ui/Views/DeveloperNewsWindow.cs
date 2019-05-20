using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace DeveloperNews.UI.Views.DevNews
{
    using static UI.Constants.Guids;

    [Guid(DeveloperNewsPaneGuidString)]
    public class DeveloperNewsWindow : ToolWindowPane
    {
        public DeveloperNewsWindow() : base(null)
        {
            Caption = "Developer News";
            Content = new DeveloperNewsControl();
        }
    }
}