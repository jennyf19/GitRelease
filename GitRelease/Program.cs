using Octokit;
using Octokit.Helpers;
using Octokit.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.PowerShell;


namespace GitRelease
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncReleaseMethod("jennyf19", "schedlua", "v1.0.1");
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
        public static async void AsyncReleaseMethod(string gitHubAccountName, string repoName, string tagName)
        {
            //A plain GitHubClient is created. You can use the default string for ProduceHeaderValue or enter your own.
            var client = new GitHubClient(new ProductHeaderValue("Testing"));

            //Enter a personal access token for the repo you want to release.
            var tokenAuth = new Credentials("6bd7587728cafa7f00c81b071e68e76c73d11577");
            
            client.Credentials = tokenAuth;

            //Enter ("GitHub Account Name", "Repo Name", and "Tag Name or Version Number (v1.0.0)" for the release)
            //var gitHubAccountName = "jennyf19";
            //var repoName = "schedlua";
            //var tagName = "v1.0.0";
            Repository result = await client.Repository.Get(gitHubAccountName, repoName);
            Console.WriteLine("The Repo Id is: " + result.Id);
            Console.WriteLine("The GitURL for the repo is: " + result.GitUrl);

            #region Create Tag

            //Enter the name of the repo to be released
            var newRelease = new NewRelease(tagName);

            //Enter the name of the release
            newRelease.Name = "This is a test";

            //Include any information you would like to share with the user in the markdown
            newRelease.Body = "This is the markdown";

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


