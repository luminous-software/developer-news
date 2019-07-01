﻿using Luminous.Code.VisualStudio.Commands;
using Luminous.Code.VisualStudio.Packages;
using Microsoft.VisualStudio.Shell;
using Tasks = System.Threading.Tasks;

namespace DeveloperNews.Commands
{
    using UI.Views.DevNews;

    internal sealed class ViewDeveloperNews : PackageCommand
    {
        private ViewDeveloperNews(AsyncPackageBase package)
            : base(package, PackageIds.ViewDeveloperNews)
        { }

        public static async Tasks.Task InstantiateAsync(AsyncPackageBase package)
            => await InstantiateAsync(new ViewDeveloperNews(package));

        protected override bool CanExecute
          => PackageClass.GeneralOptions.EnableDeveloperNews;

        protected override void OnExecute(OleMenuCommand command)
            => ExecuteCommand()
                .ShowProblem();

        private CommandResult ExecuteCommand()
            => PackageClass.ShowToolWindow<DeveloperNewsWindow>(Package.DisposalToken);
    }
}