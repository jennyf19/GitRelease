using System;
using CommandLine;
using Autofac;

namespace GitRelease
{
    class Program
    {
        static void Main(string[] args)
        {
            //Take command line parameters as input
            CommandLineInputParser options = new CommandLineInputParser();

            //Check that all the parameters are present, if not exit
            if (!Parser.Default.ParseArguments(args, options))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
                Console.ReadLine();
            }

            //Determine if tagName is in the correct format (v1.11.11)
            //If format passes, return true, and continue to ReleaseAutomator
            //If format does not pass, exit
            TagNameFormatCheck tagNameFormatCheck = new TagNameFormatCheck();
            tagNameFormatCheck.TagNameFormat(options.tagName);

            if (tagNameFormatCheck.TagNameFormat(options.tagName) == true)
            {
                //If the tagName returns true, initialize the ReleaseAutomator
                //ReleaseAutomator takes in the command line parameters and completes the repo release
                ReleaseAutomator releaseAutomator = new ReleaseAutomator();
                releaseAutomator.AsyncReleaseMethod(options.gitHubAccountName, options.repoName, options.tagName, options.personalAccessToken);

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Tag name format invalid: " + options.tagName + "\nNeeds to be in the following format: \nv1.00.000");
            }
        }
    }
}








