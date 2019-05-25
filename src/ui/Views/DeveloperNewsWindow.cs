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
            //BitmapImageMoniker = new ImageMoniker { Guid = Guid.NewGuid(), Id = 0 };  //TODO: real ImageMoniker values needed
            Content = new DeveloperNewsControl();
        }
    }
}