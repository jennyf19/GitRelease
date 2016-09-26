using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace GitReleaseLibrary
{
    public class ReleaseAutomator : IReleaseAutomator
    {
        public string GitHubAccountName { get; set; }
        public string RepoName { get; set; }
        public string TagName { get; set; }
        public string PersonalAccessToken { get; set; }
        public string Markdown { get; set; }

        public async void AsyncAuthenticationMethod()
        {
            var client = new GitHubClient(new ProductHeaderValue("Release"));

            new Credentials(PersonalAccessToken);

            Repository result = await client.Repository.Get(GitHubAccountName, RepoName);

            var newRelease = new NewRelease(TagName);

            newRelease.Name = RepoName;

            newRelease.Body = Markdown;

            newRelease.Draft = false;

            newRelease.Prerelease = false;

            //NewRelease data = newRelease;    

            // await client.Repository.Release.Create(GitHubAccountName, RepoName, newRelease);

            await client.Repository.Release.Create(result.Id, newRelease);
            
            //var tagsResult = await client.Repository.GetAllTags(result.Id);

            //var tag = tagsResult.FirstOrDefault();

            //NewRelease data = newRelease;


            /*//A plain GitHubClient is created. You can use the default string for ProduceHeaderValue or enter your own.
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

            await client.Repository.Release.Create(result.Id, newRelease);
            /*var newReleaseResult = await client.Repository.Release.Create(result.Id, newRelease);
            Console.WriteLine("\nCreated release tag: {0}", TagName);

            var tagsResult = await client.Repository.GetAllTags(result.Id);

            var tag = tagsResult.FirstOrDefault();

            NewRelease data = newRelease;

            Console.WriteLine("\nRelease of " + RepoName + " complete");*/

            Console.ReadLine();
        }
    }
}

