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

        static void Main(string[] args)
        {
            CommandLineReleaseAutomator options = new CommandLineReleaseAutomator();

            if (!Parser.Default.ParseArguments(args, options))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
                Console.ReadLine();
            }

            string GitHubAccountName = options.GitHubAccountName;
            string RepoName = options.RepoName;
            string TagName = options.TagName;
            string PersonalAccessToken = options.PersonalAccessToken;
            try
            {
                TagNameFormatCheck tagNameFormatCheck = new TagNameFormatCheck();
                tagNameFormatCheck.TagNameFormat(TagName);

                if (tagNameFormatCheck.TagNameFormat(TagName) == true)
                {
                    ReleaseAutomator releaseAutomator = new ReleaseAutomator();
                    releaseAutomator.AsyncAuthenticationMethod(GitHubAccountName, RepoName, TagName, PersonalAccessToken);

                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Tag name format invalid: ", TagName);
                }
            }
            catch (Exception a1)
            {
                Console.WriteLine(a1);
            }
        }
    }
}







