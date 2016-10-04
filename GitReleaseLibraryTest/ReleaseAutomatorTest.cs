using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GitReleaseLibrary;
using Octokit;
using System.Threading.Tasks;


namespace GitReleaseLibraryTest
{
    [TestClass]
    public class ReleaseAutomatorIncorrectUserNameTest
    {
        public string gitHubAccountName { get; set; }
        public string repoName { get; set; }
        public string tagName { get; set; }
        public string personalAccessToken { get; set; }

        [TestMethod]
        public async Task AsyncReleaseAutomator()
        {
            GitHubClient client;
            //Test connection to GitHub API
            try
            {
                client = new GitHubClient(new ProductHeaderValue("Release"));
            }
            catch (AuthorizationException authExc)
            {
                Console.WriteLine(authExc);
                throw authExc;
            }

            try
            {
                client.Credentials = new Credentials(personalAccessToken);
            }
            //Personal Access Token is invalid
            catch (ApiException apiExc)
            {
                Console.WriteLine(apiExc);
                throw (apiExc);
            }

            Repository result;
            try
            {
                result = await client.Repository.Get(gitHubAccountName, repoName);
            }
            catch (AuthorizationException authExc)
            {
                Console.WriteLine(authExc);
                throw (authExc);
            }

            //Pull readMe to inclue with the release
            string readMe;
            try
            {
                readMe = await client.Repository.Content.GetReadmeHtml(gitHubAccountName, repoName);
            }
            catch (NotFoundException notFoundExc)
            {
                Console.WriteLine(notFoundExc);
                throw (notFoundExc);
            }

            //Parameters used to create the release
            var newRelease = new NewRelease(tagName);

            newRelease.Name = repoName;

            newRelease.Body = readMe;

            newRelease.Draft = false;

            newRelease.Prerelease = false;

            try
            //Release to GitHub
            {
                await client.Repository.Release.Create(result.Id, newRelease);
            }
            catch (ApiValidationException apiExc)
            {
                Console.WriteLine(apiExc);
                throw (apiExc);
            }
            Console.WriteLine("\nRelease of " + repoName + " complete");

            Assert.Equals();
        }
         
        public Task AsyncReleaseMethod(string gitHubAccountName, string repoName, string tagName, string personalAccessToken)
        {
            throw new NotImplementedException();
        }
    }

}
