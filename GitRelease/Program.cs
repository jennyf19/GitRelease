using Octokit;
using System;
using System.Linq;
using CommandLine;
using CommandLine.Text;
using GitReleaseLibrary;
using System.Text.RegularExpressions;

namespace GitRelease
{
    class Program
    {
        //class to receive parsed values
        internal class Options
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

        static void Main(string[] args)
        {
            var options = new Options();
            if (!Parser.Default.ParseArguments(args, options))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
                Console.ReadLine();
            }
            
            try
            {
                string GitHubAccountName = options.GitHubAccountName;
                string RepoName = options.RepoName;
                string TagName = options.TagName;
                string PersonalAccessToken = options.PersonalAccessToken;

                TagNameFormatCheck tagNameFormatCheck = new TagNameFormatCheck();
                tagNameFormatCheck.TagNameFormat(TagName);

             if  (tagNameFormatCheck.TagNameFormat(TagName) == true)
                {

                    Console.WriteLine("g|itHubAccount: " + options.GitHubAccountName);

                    Console.WriteLine("r|epoName: " + options.RepoName);

                    Console.WriteLine("t|agName: " + options.TagName);

                    Console.WriteLine("p|ersonalAccessToken: " + options.PersonalAccessToken);

                    ReleaseAutomator releaseAutomator = new ReleaseAutomator();
                    releaseAutomator.AsyncAuthenticationMethod(GitHubAccountName, RepoName, TagName, PersonalAccessToken);

                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Tag name format invalid");
                }

            }

            catch (Exception a1)
            {
                Console.WriteLine(a1);
            }

        }

    }
}





