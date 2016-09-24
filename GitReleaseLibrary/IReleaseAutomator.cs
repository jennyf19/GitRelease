using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitReleaseLibrary
{
    interface IReleaseAutomator
    {
        #region Methods
        /// <summary>
        /// The AsyncRelease Method is an asyncronous method. 
        /// It creates a plain GitHubClient that includes a User-Agent header.
        /// Authenticated access to the repo is used via personal access token.
        /// The repo is tagged and released with the new of the repo, a name for the release, and
        /// a markdown can be included. newRelease.Draft and newRelease.Prerelease are booleans and
        /// the defaults for both is false. 
        /// </summary>

        public async void AsyncReleaseMethod(string GitHubAccountName, string RepoName, string TagName, string PersonalAccessToken, string Markdown)
        {
            //A plain GitHubClient is created. You can use the default string for ProduceHeaderValue or enter your own.
            var client = new GitHubClient(new ProductHeaderValue("Release"));

            //Enter a personal access token for the repo you want to release.
            //var tokenAuth = new Credentials("");

            //Console.WriteLine("Enter your personal access token for the repo: ");
            var inputAccessToken = new Credentials(PersonalAccessToken);
            client.Credentials = inputAccessToken;

            Repository result = await client.Repository.Get(GitHubAccountName, RepoName);

            #region Create Tag

            //Enter the name of the repo to be released
            var newRelease = new NewRelease(TagName);

            //Enter the name of the release
            //Console.WriteLine("Enter the name of the release: ");

            newRelease.Name = RepoName;

            //Include any information you would like to share with the user in the markdown

            newRelease.Body = Markdown;

            //The Draft plag is used to indicate when a release should be published
            newRelease.Draft = false;

            //Indicates whether a release is unofficial or preview release
            newRelease.Prerelease = false;

            #endregion
        }
    }
