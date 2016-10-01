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
        public static string GitHubAccountName;
        public static string RepoName;
        public static string TagName;
        public static string PersonalAccessToken;

        static void Main(string[] args)
        {
            
            CommandLineOptions commandLineOptions = new CommandLineOptions();
            commandLineOptions.CommandLineInput(args, GitHubAccountName, RepoName, TagName, PersonalAccessToken);
            
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





