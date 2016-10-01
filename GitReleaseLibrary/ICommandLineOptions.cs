using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using CommandLine;
using CommandLine.Text;

namespace GitReleaseLibrary
{
    interface ICommandLineOptions
    {
        [Option('g', "GitHubAccountName", Required = true, HelpText = "Enter the GitHub Account Name for the repository you want to release")]
        string GitHubAccountName { get; set; }

        [Option('r', "RepoName", Required = true, HelpText = "Enter the name of the repository you want to release")]
        string RepoName { get; set; }

        [Option('t', "TagName", Required = true, HelpText = "Enter the tag name for the repository you want to release (ex. v1.0.0")]
        string TagName { get; set; }

        [Option('p', "PersonalAccessToken", Required = true, HelpText = "Enter the personal access token for the account")]
        string PersonalAccessToken { get; set; }

        string[] CommandLineInput(string[] args, out string[] outPut);

    }
}
