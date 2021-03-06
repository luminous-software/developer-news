﻿namespace DeveloperNews.Commands
{
    using DeveloperNews.Options.Pages;

    using Luminous.Code.VisualStudio.Commands;
    using Luminous.Code.VisualStudio.Packages;

    internal abstract class DeveloperNewsCommand : AsyncDynamicCommand
    {
        protected DeveloperNewsCommand(AsyncPackageBase package, int id) : base(package, id)
        { }

        protected override bool CanExecute
           => base.CanExecute && GeneralOptions.Instance.EnableDeveloperNews;
    }
}