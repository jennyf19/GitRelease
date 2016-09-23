using Octokit;

using System;
using System.Linq;


namespace GitRelease
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("parameter count = {0}", args.Length);

            string gitHubAccountName = args[0];
            string repoName = args[1];
            string tagName = args[2];
            string body = args[3];
            //string releaseName = args[3];
            //string body = args[4];
            
            for (int i = 0; i < args.Length; i++)
            {
                System.Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            }

            /*Console.WriteLine("Enter your GitHub Account Name: ");
            string gitHubAccountName = (Console.ReadLine());
            gitHubAccountName = args[0];

            Console.WriteLine("Enter the name of the repo to be released: ");
            string repoName = (Console.ReadLine());
            repoName = args[1];

            Console.WriteLine("Enter a tag name for the repo (ex. v1.0.0): ");
            string tagName = (Console.ReadLine());*/

            AsyncReleaseMethod(gitHubAccountName, repoName, tagName, body);

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

        public static async void AsyncReleaseMethod(string gitHubAccountName, string repoName, string tagName, string body)
        {
            //A plain GitHubClient is created. You can use the default string for ProduceHeaderValue or enter your own.
            var client = new GitHubClient(new ProductHeaderValue("Testing"));

            //Enter a personal access token for the repo you want to release.
            //var tokenAuth = new Credentials("");

            //Console.WriteLine("Enter your personal access token for the repo: ");
            var accessToken = new Credentials("");
            client.Credentials = accessToken;

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



