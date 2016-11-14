using System;
using CommandLine;
using GitReleaseAutomator;
using Nito.AsyncEx;

namespace GitRelease
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }

        static async void MainAsync(string[] args)
        { 
            //Take command line parameters as input
            CommandLineInputParser options = new CommandLineInputParser();

            //Check that all the parameters are present, if not exit
            if (!Parser.Default.ParseArguments(args, options))
            {
                Console.ReadLine();
                Environment.Exit(Parser.DefaultExitCodeFail);
            }

            //Determine if tagName is in the correct format (vd.dd.dd)
            //If format passes, continue to ReleaseAutomator
            //If format does not pass, exit
            if (TagNameFormat.IsValid(options.tagName))
            {
                //Initialize the ReleaseAutomator
                //ReleaseAutomator takes in the command line parameters and completes the repo release
                ReleaseAutomator releaseAutomator = new ReleaseAutomator();
                await releaseAutomator.AsyncReleaseMethod(options.gitHubAccountName, options.repoName, options.tagName, options.personalAccessToken);
            }
            else
            {
                Console.WriteLine("Tag name format invalid: " + options.tagName + "\nUse Semantic Versioning (vd.dd.dd).");
            }
            Console.ReadLine();
        }
    }
}