using Luminous.Code.VisualStudio.Options.Pages;

using System.ComponentModel;

namespace DeveloperNews.Options.Pages
{
    using static Constants.PageConstants;
    using static Core.Constants.StringConstants;

    public class GeneralOptions : BaseOptionModel<GeneralOptions>
    {
        [Category(H1 + PackageName)]
        [DisplayName(Enable + Space + Quote + PackageName + Quote)]
        [Description("Allows the whole set of '" + PackageName + "' features to be turned off together")]
        public bool EnableDeveloperNews { get; set; } = true;

        [Category(H1 + PackageName)]
        [DisplayName(Constants.PageConstants.PackageVersion)]
        [Description("Installed '" + PackageName + "' version")]
        public string PackageVersion { get; } = Vsix.Version;

        [Category(H2 + Features)]
        [DisplayName(Constants.PageConstants.FeedUrl)]
        [Description("The url that the news feeds gets its items from")]
        public string FeedUrl { get; set; } = "https://vsstartpage.blob.core.windows.net/news/vs";

        [Category(H2 + Features)]
        [DisplayName(Constants.PageConstants.ItemsToDisplay)]
        [Description("Determines the number of items displayed in the list")]
        public int ItemsToDisplay { get; set; } = 10;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + Quote + Constants.PageConstants.OpenLinksInVS + Quote)]
        [Description("Determines if links are opened in VS or in the user's default browser")]
        public bool OpenLinksInVS { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + Quote + Constants.PageConstants.EnableDeveloperNewsOptions + Quote)]
        [Description("Determines if a button to open" + Space + Quote + PackageName + Quote + Space + "options is added to the" + Space + Quote + "Tools" + Quote + Space + "Menu")]
        public bool EnableDeveloperNewsOptions { get; set; } = true;
    }
}