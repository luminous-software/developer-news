﻿using System;

namespace DeveloperNews.UI.Interfaces
{
    public interface IVisualStudioService
    {
        void ExecuteCommand(string action, string path);

        void ShowMessage(string message);

        void OpenWebPage(string url, bool internalBrowser);

        void OpenFolder(string path = "");

        //void OpenSolution(string path = null);

        void OpenProject(string path = "");

        void CreateNewProject();

        void CloneOrCheckoutCode();

        void ShowToolsOptions(Guid guid);
    }
}