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
            CommandLineInputParser options = new CommandLineInputParser();

            if (!Parser.Default.ParseArguments(args, options))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
                Console.ReadLine();
            }

            string gitHubAccountName = options.gitHubAccountName;
            string repoName = options.repoName;
            string tagName = options.tagName;
            string personalAccessToken = options.personalAccessToken;
            try
            {
                TagNameFormatCheck tagNameFormatCheck = new TagNameFormatCheck();
                tagNameFormatCheck.TagNameFormat(tagName);

                if (tagNameFormatCheck.TagNameFormat(tagName) == true)
                {
                    ReleaseAutomator releaseAutomator = new ReleaseAutomator();
                    releaseAutomator.AsyncReleaseMethod(gitHubAccountName, repoName, tagName, personalAccessToken);

                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Tag name format invalid: ", tagName);
                }
            }
            catch (Exception a1)
            {
                Console.WriteLine(a1);
            }
        }
    }
}







