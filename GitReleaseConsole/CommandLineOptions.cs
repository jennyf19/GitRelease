﻿using CommandLine;
using CommandLine.Text;

namespace GitRelease
{
    public class CommandLineInputParser : ICommandLineInputParser
    {
        [Option('u', "GitHubAccount", Required = true, HelpText = "Enter the GitHub Account Name with access to the repository you want to release")]
        public string gitHubAccountName { get; set; }

        [Option('r', "RepoName", Required = true, HelpText = "Enter the name of the repository you want to release")]
        public string repoName { get; set; }

        [Option('t', "TagName", Required = true, HelpText = "Enter the tag name for the repository you want to release (ex. vd.dd.dd")]
        public string tagName { get; set; }

        [Option('a', "PersonalAccessToken", Required = true, HelpText = "Enter the personal access token for the account")]
        public string personalAccessToken { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}