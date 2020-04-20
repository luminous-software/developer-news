using Luminous.Code.VisualStudio.Commands;
using Luminous.Code.VisualStudio.Packages;

using Microsoft.VisualStudio.Shell;

using Tasks = System.Threading.Tasks;

namespace DeveloperNews.Commands
{
    using Options.Pages;

    internal sealed class ViewDeveloperNewsOptions : DeveloperNewsCommand
    {
        private ViewDeveloperNewsOptions(AsyncPackageBase package)
            : base(package, PackageIds.ViewDeveloperNewsOptions)
        { }

        public static async Tasks.Task InstantiateAsync(AsyncPackageBase package)
            => await InstantiateAsync(new ViewDeveloperNewsOptions(package));

        protected override bool CanExecute
          => base.CanExecute && GeneralOptions.Instance.EnableDeveloperNewsOptions;

        protected override void OnExecute(OleMenuCommand command)
            => ExecuteCommand()
                .ShowProblem();

        private CommandResult ExecuteCommand()
            => Package?.ShowOptionsPage<DialogPageProvider.General>();
    }
}