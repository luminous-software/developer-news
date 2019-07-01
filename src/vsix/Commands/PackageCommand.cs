namespace DeveloperNews.Commands
{
    using Luminous.Code.VisualStudio.Commands;
    using Luminous.Code.VisualStudio.Packages;

    internal abstract class PackageCommand : AsyncDynamicCommand
    {
        protected PackageCommand(AsyncPackageBase package, int id) : base(package, id)
        {
        }

        protected override bool CanExecute
           => PackageClass.GeneralOptions.EnableDeveloperNews;
    }
}