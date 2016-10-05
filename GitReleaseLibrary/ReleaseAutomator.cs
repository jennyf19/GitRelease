using CommandLine;
using System;
using Octokit;
using System.Threading.Tasks;

namespace GitReleaseLibrary
{
    public class ReleaseAutomator : IReleaseAutomator
    {
        #region For Dependency Injection
        //private IGitHubClient _client;
        //public IGitHubClient client {
        //    get
        //    {
        //        if (client == null)
        //        {
        //            GitHubClient _client = new GitHubClient(new ProductHeaderValue("GitRelease"));
        //        }
        //        return _client;
        //    }
        //    set
        //    {
        //        _client = value;
        //    }
        //}
        #endregion

        public async Task AsyncReleaseMethod(string gitHubAccountName, string repoName, string tagName, string personalAccessToken)
        {
            try
            {
                //Test connection to GitHub API
                GitHubClient client = new GitHubClient(new ProductHeaderValue("GitRelease"));
                client.Credentials = new Credentials(personalAccessToken);
                Repository result = await client.Repository.Get(gitHubAccountName, repoName);

                //Pull readMe to inclue with the release
                string readMe = await client.Repository.Content.GetReadmeHtml(gitHubAccountName, repoName);

                //Parameters used to create the release
                var newRelease = new NewRelease(tagName);
                newRelease.Name = repoName;
                newRelease.Body = readMe;
                newRelease.Draft = false;
                newRelease.Prerelease = false;

                //Release to GitHub
                await client.Repository.Release.Create(result.Id, newRelease);
                Console.WriteLine("Release of " + repoName + " complete");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}