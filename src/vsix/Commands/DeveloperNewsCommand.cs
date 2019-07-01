using Luminous.Code.VisualStudio.Commands;
using Luminous.Code.VisualStudio.Packages;
using Microsoft.VisualStudio.Shell;
using Tasks = System.Threading.Tasks;

namespace DeveloperNews.Commands
{
    using UI.Views.DevNews;

    internal sealed class DeveloperNewsCommand : AsyncDynamicCommand
    {
        private DeveloperNewsCommand(AsyncPackageBase package)
            : base(package, PackageIds.DeveloperNewsCommand)
        { }

        public static async Tasks.Task InstantiateAsync(AsyncPackageBase package)
            => await InstantiateAsync(new DeveloperNewsCommand(package));

        protected override bool CanExecute
          => PackageClass.GeneralOptions.DeveloperNewsEnabled;

        protected override void OnExecute(OleMenuCommand command)
            => ExecuteCommand()
                .ShowProblem();

        private CommandResult ExecuteCommand()
            => PackageClass.ShowToolWindow<DeveloperNewsWindow>(Package.DisposalToken);
    }
}