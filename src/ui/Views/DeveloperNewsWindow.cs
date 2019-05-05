using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace DeveloperNews.UI.Views
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