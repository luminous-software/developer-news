using System;

namespace DeveloperNews.UI.Interfaces
{
    using Observables;

    public interface INewsItemCommandService
    {
        ObservableCommandList GetCommands(Action refresh);

    }
}