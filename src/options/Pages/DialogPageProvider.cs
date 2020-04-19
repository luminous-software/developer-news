using Luminous.Code.VisualStudio.Options.Pages;

using System;
using System.Runtime.InteropServices;

namespace DeveloperNews.Options.Pages
{
    using static DeveloperNews.Options.Constants.OptionsGuids;

    // A provider for custom DialogPage implementations
    public class DialogPageProvider
    {
        [Guid(GeneralDialogPageString)]
        public class General : BaseOptionPage<GeneralOptions> { }
    }
}