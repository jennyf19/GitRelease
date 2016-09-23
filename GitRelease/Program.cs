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

            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }

            Console.WriteLine("g|itHubAccount: " + options.GitHubAccountName);

            Console.WriteLine("r|epoName: " + options.RepoName);

            Console.WriteLine("t|agName: " + options.TagName);

            Console.WriteLine("p|ersonalAccessToken: " + options.PersonalAccessToken);

            Console.WriteLine("m|arkdown: " + options.Markdown);


            //Console.WriteLine("b|ool: " + options.BooleanValue.ToString().ToLowerInvariant());

            Console.WriteLine("\nParameter count for GitRelease = {0}", args.Length);

            string gitHubAccountName = args[0];
            string repoName = args[1];
            string tagName = args[2];
            string accessToken = args[3];
            string body = args[4];

            Console.WriteLine("\nThe input order is:\nGitHub Account Name, Repo Name, Tag Name, Personal Access Token, and Markdown\nYou entered:");

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            }

            AsyncReleaseMethod(gitHubAccountName, repoName, tagName, accessToken, body);

            Console.ReadLine();
        }


        #region Methods
        /// <summary>
        /// The AsyncRelease Method is an asyncronous method. 
        /// It creates a plain GitHubClient that includes a User-Agent header.
        /// Authenticated access to the repo is used via personal access token.
        /// The repo is tagged and released with the new of the repo, a name for the release, and
        /// a markdown can be included. newRelease.Draft and newRelease.Prerelease are booleans and
        /// the defaults for both is false. 
        /// </summary>

        public static async void AsyncReleaseMethod(string gitHubAccountName, string repoName, string tagName, string accessToken, string body)
        {
            //A plain GitHubClient is created. You can use the default string for ProduceHeaderValue or enter your own.
            var client = new GitHubClient(new ProductHeaderValue("Release"));

            //Enter a personal access token for the repo you want to release.
            //var tokenAuth = new Credentials("");

            //Console.WriteLine("Enter your personal access token for the repo: ");
            var inputAccessToken = new Credentials(accessToken);
            client.Credentials = inputAccessToken;

            Repository result = await client.Repository.Get(gitHubAccountName, repoName);

            #region Create Tag

            //Enter the name of the repo to be released
            var newRelease = new NewRelease(tagName);

            //Enter the name of the release
            //Console.WriteLine("Enter the name of the release: ");

            newRelease.Name = repoName;

            //Include any information you would like to share with the user in the markdown

            newRelease.Body = body;

            //The Draft plag is used to indicate when a release should be published
            newRelease.Draft = false;

            //Indicates whether a release is unofficial or preview release
            newRelease.Prerelease = false;

            #endregion

            #region The Release

            ///To create a new release, you must have a corresponding tag for the repo

            var newReleaseResult = await client.Repository.Release.Create(result.Id, newRelease);

            Console.WriteLine("\nCreated release tag: {0}", tagName);

            var tagsResult = await client.Repository.GetAllTags(result.Id);

            var tag = tagsResult.FirstOrDefault();

            NewRelease data = newRelease;

            Console.WriteLine("\nRelease of " + repoName + " complete");

            Console.ReadLine();
        }
        #endregion
        #endregion
    }

}



