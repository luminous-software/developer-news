using Microsoft.VisualStudio.Shell;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DeveloperNews.Options.Pages
{
    using static Constants.OptionsGuids;
    using static Constants.PageConstants;
    using static Core.Constants.StringConstants;

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    [Guid(GeneralDialogPageString)]
    public class GeneralDialogPage : DialogPage
    {
        [Category(H1 + PackageName)]
        [DisplayName(Enable + Space + PackageName)]
        [Description("Allows the whole set of " + PackageName + " features to be turned off together")]
        public bool PackageNameEnabled { get; set; } = true;

        [Category(H1 + PackageName)]
        [DisplayName(Constants.PageConstants.PackageVersion)]
        [Description("Installed " + PackageName + " version")]
        public string PackageVersion { get; } = Vsix.Version;
    }
}