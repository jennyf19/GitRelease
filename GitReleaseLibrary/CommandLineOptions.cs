using System;
using CommandLine;
using CommandLine.Text;

namespace GitReleaseLibrary
{
    public class CommandLineOptions //: ICommandLineOptions
    {
        public class Options
        {
            [Option('g', "GitHubAccount", Required = true, HelpText = "Enter the GitHub Account Name for the repository you want to release")]
            public string GitHubAccountName { get; set; }

            [Option('r', "RepoName", Required = true, HelpText = "Enter the name of the repository you want to release")]
            public string RepoName { get; set; }

            [Option('t', "TagName", Required = true, HelpText = "Enter the tag name for the repository you want to release (ex. v1.0.0")]
            public string TagName { get; set; }

            [Option('p', "PersonalAccessToken", Required = true, HelpText = "Enter the personal access token for the account")]
            public string PersonalAccessToken { get; set; }

            [HelpOption]
            public string GetUsage()
            {
                return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
            }

        }
        public bool CommandLineInput(string[] args, string GitHubAccountName, string RepoName, string TagName, string PersonalAccessToken)
        {
            var options = new Options();

            if (!Parser.Default.ParseArguments(args, options))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
                Console.ReadLine();
                return false;
            }
            else
            {
                GitHubAccountName = options.GitHubAccountName;
                RepoName = options.RepoName;
                TagName = options.TagName;
                PersonalAccessToken = options.PersonalAccessToken;

                return true;
            }

        }
    }
}