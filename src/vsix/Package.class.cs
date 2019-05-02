﻿using Luminous.Code.Exceptions.ExceptionExtensions; //TODO: remove
using Luminous.Code.VisualStudio.Commands; //TODO: remove
using Luminous.Code.VisualStudio.Packages;
using Microsoft.VisualStudio; //TODO: remove
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop; //TODO: remove
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Tasks = System.Threading.Tasks;

namespace DeveloperNews
{
    using Commands;
    using Options.Pages;
    using UI.Views;
    using static Core.Constants.StringConstants;
    using static PackageGuids;
    using static Vsix;

    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]

    [InstalledProductRegistration(Name, Description, Version)]
    [Guid(PackageString)]

    [ProvideOptionPage(typeof(GeneralDialogPage), Name, General, 0, 0, supportsAutomation: true)]
    [ProvideToolWindow(typeof(DeveloperNewsWindow))]

    public sealed class PackageClass : AsyncPackageBase
    {
        public PackageClass() : base(PackageCommandSet, Name, Description)
        { }

        protected override async Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);
            await DeveloperNewsCommand.InstantiateAsync(this);
            //await TestToolWindowCommand.InitializeAsync(this);

            //await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        }

        //TODO: remove
        public static CommandResult ShowToolWindow<T>(CancellationToken cancellationToken, string problem = null)
            where T : ToolWindowPane
        {
            try
            {
                Instance.JoinableTaskFactory.RunAsync(async delegate
                {
                    ToolWindowPane window = await Instance.ShowToolWindowAsync(typeof(T), 0, true, cancellationToken);
                    if ((null == window) || (null == window.Frame))
                    {
                        throw new NotSupportedException("Cannot create tool window");
                    }

                    await Instance.JoinableTaskFactory.SwitchToMainThreadAsync();

                    IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
                    ErrorHandler.ThrowOnFailure(windowFrame.Show());
                });

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ProblemResult(problem ?? ex.ExtendedMessage());
            }
        }

        public static CommandResult ShowToolWindow(Type type, string problem = null)
        {
            try
            {
                Instance.JoinableTaskFactory.RunAsync(async delegate
                {
                    ToolWindowPane window = await Instance.ShowToolWindowAsync(type, 0, true, Instance.DisposalToken);
                    if ((null == window) || (null == window.Frame))
                    {
                        throw new NotSupportedException("Cannot create tool window");
                    }

                    await Instance.JoinableTaskFactory.SwitchToMainThreadAsync();

                    IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
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
