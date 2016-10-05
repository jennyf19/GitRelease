using System;
using CommandLine;
using Autofac;
using GitReleaseLibrary;

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
                Console.ReadLine();
                Environment.Exit(Parser.DefaultExitCodeFail);
            }

            //Determine if tagName is in the correct format (v1.11.11)
            //If format passes, continue to ReleaseAutomator
            //If format does not pass, exit
            if (TagNameFormatCheck.TagNameFormat(options.tagName))
            {
                //Initialize the ReleaseAutomator
                //ReleaseAutomator takes in the command line parameters and completes the repo release
                ReleaseAutomator releaseAutomator = new ReleaseAutomator();
                releaseAutomator.AsyncReleaseMethod(options.gitHubAccountName, options.repoName, options.tagName, options.personalAccessToken);
            }
            else
            {
                Console.WriteLine("Tag name format invalid: " + options.tagName + "\nNeeds to be in the following format: \nv1.00.000");
            }
            Console.ReadLine();
        }
    }
}