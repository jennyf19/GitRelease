using Octokit;
using System;
using System.Linq;
using CommandLine;
using CommandLine.Text;


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

            [Option('m', "Markdown", Required = true, HelpText = "This is the markdown for the release")]
            public string Markdown { get; set; }

            [HelpOption]
            public string GetUsage()
            {
                return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
            }
        }
        
        static void Main(string[] args)
        {
            var options = new Options();

            if (Parser.Default.ParseArguments(args, options))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
            }

            Console.WriteLine("g|itHubAccount: " + options.GitHubAccountName);

            Console.WriteLine("r|epoName: " + options.RepoName);

            Console.WriteLine("t|agName: " + options.TagName);

            Console.WriteLine("p|ersonalAccessToken: " + options.PersonalAccessToken);

            Console.WriteLine("m|arkdown: " + options.Markdown);

            //Console.WriteLine("b|ool: " + options.BooleanValue.ToString().ToLowerInvariant());

            /*Console.WriteLine("\nParameter count for GitRelease = {0}", args.Length);

            options.GitHubAccountName = args[0];
            options.RepoName = args[1];
            options.TagName = args[2];
            options.PersonalAccessToken = args[3];
            options.Markdown = args[4];

            string gitHubAccountName = args[0];
            string repoName = args[1];
            string tagName = args[2];
            string accessToken = args[3];
            string body = args[4];

            Console.WriteLine("\nThe input order is:\nGitHub Account Name, Repo Name, Tag Name, Personal Access Token, and Markdown\nYou entered:");

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            }*/
            string GitHubAccountName = options.GitHubAccountName;
            string RepoName = options.RepoName;
            string TagName = options.TagName;
            string PersonalAccessToken = options.PersonalAccessToken;
            string Markdown = options.Markdown;

            AsyncReleaseMethod(GitHubAccountName, RepoName, TagName, PersonalAccessToken, Markdown);

            Console.ReadLine();
        }

       

            #region The Release

            ///To create a new release, you must have a corresponding tag for the repo

            var newReleaseResult = await client.Repository.Release.Create(result.Id, newRelease);

            Console.WriteLine("\nCreated release tag: {0}", TagName);

            var tagsResult = await client.Repository.GetAllTags(result.Id);

            var tag = tagsResult.FirstOrDefault();

            NewRelease data = newRelease;

            Console.WriteLine("\nRelease of " + RepoName + " complete");

            Console.ReadLine();
        }
        #endregion
        #endregion
    }

}



