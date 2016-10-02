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
            var builder = new ContainerBuilder();
            builder.RegisterType<CommandLineInputParser>().As<ICommandLineInputParser>();
            builder.RegisterType<TagNameFormatCheck>().As<ITagNameFormatCheck>();
            builder.RegisterType<ReleaseAutomator>().As<IReleaseAutomator>();
            Container = builder.Build();
        
            using (var scope = Container.BeginLifetimeScope())
            {
                var release = scope.Resolve<IReleaseAutomator>();
            }
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








