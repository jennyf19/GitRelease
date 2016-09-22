using Octokit;
using Octokit.Helpers;
using Octokit.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using CommandLine;
using CommandLine.Text;
using System.Diagnostics;

namespace GitRelease
{
    class Program
    {
        static void Main(string[] args)
        {

           Options options = new Options();
             Parser parser = new Parser();
             if (parser.ParseArguments(args, options))
             {
                 if (options.Verbose)
                 {
                     Console.WriteLine(options.InputName);
                     Console.WriteLine(options.InputRepoName);
                     Console.WriteLine(options.InputTagName);
                     Console.WriteLine(options.InputAccessToken);
                 }
                 else
                     Console.WriteLine("working...");
             }
             else
             {
                 Console.WriteLine("Doing something random");
             }
            Console.WriteLine("Enter your GitHub Account Name: ");
            string gitHubAccountName = (Console.ReadLine());

            Console.WriteLine("Enter the name of the repo to be released: ");
            string repoName = (Console.ReadLine());

            Console.WriteLine("Enter a tag name for the repo (ex. v1.0.0): ");
            string tagName = (Console.ReadLine());

            AsyncReleaseMethod(gitHubAccountName, repoName, tagName);

            Console.ReadLine();
        }

        class Options
        {
            [Option('g', "Name", Required = true, HelpText = "Input your GitHub Account Name.")]
            public string InputName { get; set; }

            [Option('r', "repoName", Required = true, HelpText = "Input your RepoName.")]
            public string InputRepoName { get; set; }

            [Option('t', "tagName", Required = true, HelpText = "Input a tag name (ex. v1.0.0")]
            public string InputTagName { get; set; }

            [Option('a', "accessToken", Required = true, HelpText = "Input your personal access token")]
            public string InputAccessToken { get; set; }

            [Option('v', null, HelpText = "Print details during execution")]
            public bool Verbose { get; set; }

            [HelpOption]
            public string GetUsage()
            {
                var usage = new StringBuilder();
                usage.AppendLine("Quickstart Application 1.0");
                usage.AppendLine("Read user manual for usage instructions...");
                return usage.ToString();
            }
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
        
        public static async void AsyncReleaseMethod(string gitHubAccountName, string repoName, string tagName)
        {
            //A plain GitHubClient is created. You can use the default string for ProduceHeaderValue or enter your own.
            var client = new GitHubClient(new ProductHeaderValue("Testing"));

            //Enter a personal access token for the repo you want to release.
            //var tokenAuth = new Credentials("");
                  
            //Console.WriteLine("Enter your personal access token for the repo: ");
            var accessToken = new Credentials("30aa51733b5b275875758ab2e6a5a06784f522fd");
            client.Credentials = accessToken;

            //Enter ("GitHub Account Name", "Repo Name", and "Tag Name or Version Number (v1.0.0)" for the release)
            //var gitHubAccountName = "jennyf19";
            //var repoName = "schedlua";
            //var tagName = "v1.0.0";
            Console.WriteLine(gitHubAccountName + ", " + repoName + ", " + tagName);

            Repository result = await client.Repository.Get(gitHubAccountName, repoName);
            Console.WriteLine("The Repo Id is: " + result.Id);
            Console.WriteLine("The GitURL for the repo is: " + result.GitUrl);

            #region Create Tag

            //Enter the name of the repo to be released
            var newRelease = new NewRelease(tagName);

            //Enter the name of the release
            //Console.WriteLine("Enter the name of the release: ");

            newRelease.Name = ("something here");

            //Include any information you would like to share with the user in the markdown
            //Console.WriteLine("Add information for the markdown: ");

            newRelease.Body = ("something else here");

            //The Draft plag is used to indicate when a release should be published
            newRelease.Draft = false;

            //Indicates whether a release is unofficial or preview release
            newRelease.Prerelease = false;

            #endregion

            #region The Release

            ///To create a new release, you must have a corresponding tag for the repo

            var newReleaseResult = await client.Repository.Release.Create(result.Id, newRelease);

            Console.WriteLine("Created release tag: {0}", tagName);

            var tagsResult = await client.Repository.GetAllTags(result.Id);

            var tag = tagsResult.FirstOrDefault();

            NewRelease data = newRelease;

            Console.WriteLine("Release of " + repoName + " complete");

            Console.ReadLine();
        }
        #endregion
        #endregion
    }

}



