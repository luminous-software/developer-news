using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace DeveloperNews.UI.Views
{
    [Guid("c9bf5581-daeb-494d-b2c6-46f9e666d69a")]
    public class DatabaseManagerWindow : ToolWindowPane
    {
        public DatabaseManagerWindow() : base(null)
        {
            Caption = "Database Manager";
            Content = new DatabaseManagerControl();
        }
    }
}