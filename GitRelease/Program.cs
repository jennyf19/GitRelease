using System;
using CommandLine;
using GitReleaseLibrary;
using Autofac;

namespace GitRelease
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            //Dependency injection 
            var builder = new ContainerBuilder();
            builder.RegisterType<CommandLineInputParser>().As<ICommandLineInputParser>();
            builder.RegisterType<TagNameFormatCheck>().As<ITagNameFormatCheck>();
            builder.RegisterType<ReleaseAutomator>().As<IReleaseAutomator>();
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var release = scope.Resolve<IReleaseAutomator>();
            }

            //Take command line parameters as input
            CommandLineInputParser options = new CommandLineInputParser();

            //Check that all the parameters are present, if not exit
            if (!Parser.Default.ParseArguments(args, options))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
                Console.ReadLine();
            }

            //Parse the parameters
            string gitHubAccountName = options.gitHubAccountName;
            string repoName = options.repoName;
            string tagName = options.tagName;
            string personalAccessToken = options.personalAccessToken;

            //Determine if tagName is in the correct format (v1.11.11)
            //If format passes, return true and continue to ReleaseAutomator
            //If format does not pass, exit program
            try
            {
                TagNameFormatCheck tagNameFormatCheck = new TagNameFormatCheck();
                tagNameFormatCheck.TagNameFormat(tagName);

                if (tagNameFormatCheck.TagNameFormat(tagName) == true)
                {
                    //If the tagName returns true, initialize the ReleaseAutomator
                    //ReleaseAutomator takes in the command line parameters and completes the repo release
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








