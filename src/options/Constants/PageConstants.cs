﻿namespace DeveloperNews.Options.Constants
{
    using static Core.Constants.StringConstants;

    public static class PageConstants
    {
        public const string H1 = "1." + Space;
        public const string H2 = "2." + Space;
        public const string Feature = "Feature";
        public const string Features = "Features";
        public const string FeatureSet = "Feature Set";
        public const string Enable = "Enable";
        public const string Enabled = "Enabled";
        public const string EnablesDisables = "Enables/disables";
        public const string EnablesDisablesAll = EnablesDisables + Space + "ALL";

        public const string PackageName = Vsix.Name;
        public const string PackageFeatureSet = PackageName + Space + FeatureSet;
        public const string PackageVersion = "Version Number";
        public const string FeedUrl = "Feed Url";
        public const string OpenLinksInVS = "Open Links in VS";
        public const string ItemsToDisplay = "Number of items to display";
        public const string ClearListBeforeRefresh = "Clear list before refresh";
        public const string EnableDeveloperNewsOptions = "Developer News Options";
    }
}