﻿using Luminous.Code.Extensions.ExceptionExtensions; //TODO: remove
using Luminous.Code.VisualStudio.Commands; //TODO: remove
using Luminous.Code.VisualStudio.Packages;

using Microsoft.VisualStudio; //TODO: remove
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop; //TODO: remove Microsoft.VisualStudio.Shell.Interop

using System;
using System.Runtime.InteropServices;
using System.Threading;

using Tasks = System.Threading.Tasks;

namespace DeveloperNews
{
    using Commands;

    using Options.Pages;

    using UI.ViewModels;
    using UI.Views.DevNews;

    using static Core.Constants.StringConstants;
    using static PackageGuids;
    using static Vsix;

    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]

    [InstalledProductRegistration(Name, Description, Version)]
    [Guid(PackageString)]

    [ProvideOptionPage(typeof(GeneralDialogPage), Name, General, 0, 0, supportsAutomation: true)]
    [ProvideToolWindow(typeof(NewsItemsWindow), Style = VsDockStyle.Tabbed, Window = "E13EEDEF-B531-4afe-9725-28A69FA4F896", MultiInstances = false)]

    public sealed class PackageClass : AsyncPackageBase
    {
        private static GeneralDialogPage generalOptions;

        public static GeneralDialogPage GeneralOptions
            => generalOptions ?? (generalOptions = GetDialogPage<GeneralDialogPage>());

        public PackageClass() : base(PackageCommandSet, Name, Description)
            => _ = new ViewModelLocator();

        protected override async Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);
            await ViewDeveloperNews.InstantiateAsync(this);
            await DeveloperNewsOptions.InstantiateAsync(this);

            //await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        }

        //TODO: remove ShowToolWindow<T>(CancellationToken cancellationToken, string problem = null)
        public static CommandResult ShowToolWindow<T>(CancellationToken cancellationToken, string problem = null)
            where T : ToolWindowPane
        {
            try
            {
                Instance.JoinableTaskFactory.RunAsync(async delegate
                {
                    var window = await Instance.ShowToolWindowAsync(typeof(T), 0, true, cancellationToken);
                    if ((null == window) || (null == window.Frame))
                    {
                        throw new NotSupportedException("Cannot create tool window");
                    }

                    await Instance.JoinableTaskFactory.SwitchToMainThreadAsync();

                    var windowFrame = (IVsWindowFrame)window.Frame;
                    ErrorHandler.ThrowOnFailure(windowFrame.Show());
                });

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ProblemResult(problem ?? ex.ExtendedMessage());
            }
        }

        //TODO: remove ShowToolWindow<T>(Type type, string problem = null)
        public static CommandResult ShowToolWindow(Type type, string problem = null)
        {
            try
            {
                Instance.JoinableTaskFactory.RunAsync(async delegate
                {
                    var window = await Instance.ShowToolWindowAsync(type, 0, true, Instance.DisposalToken);
                    if ((null == window) || (null == window.Frame))
                    {
                        throw new NotSupportedException("Cannot create tool window");
                    }

                    await Instance.JoinableTaskFactory.SwitchToMainThreadAsync();

                    var windowFrame = (IVsWindowFrame)window.Frame;
                    ErrorHandler.ThrowOnFailure(windowFrame.Show());
                });

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ProblemResult(problem ?? ex.ExtendedMessage());
            }
        }
    }
}
