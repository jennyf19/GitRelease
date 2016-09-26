using Xunit;
using Octokit;
using NUnit;
using System;
using System.Linq;

namespace UnitTestProject
{
    public class AsyncReleaseMethodTest
    {
        [Fact]
        public void ReturnCredentials()
        {
            var client = new GitHubClient(new ProductHeaderValue("Release"));

            string PersonalAccessToken = "e37dca0b4c9672bec7583a70df03202adfc00063";

            new Credentials(PersonalAccessToken);

            //PersonalAccessToken = client.Credentials.ToString();
            Assert.True(true, PersonalAccessToken);
        }
        [Fact]
        public async void ReleaseRepoTest()
        {
            string GitHubAccountName = "jennyf19";
            string RepoName = "BinaryTree";
            string TagName = "v1.1.32";
            string Markdown = "something here";
            string PersonalAccessToken = "e37dca0b4c9672bec7583a70df03202adfc00063";

            var client = new GitHubClient(new ProductHeaderValue("Release"));

            new Credentials(PersonalAccessToken);

            Repository result = await client.Repository.Get(GitHubAccountName, RepoName);

            var newRelease = new NewRelease(TagName);

            newRelease.Name = RepoName;

            newRelease.Body = Markdown;

            newRelease.Draft = false;

            newRelease.Prerelease = false;

            //NewRelease data = newRelease;    

            await client.Repository.Release.Create(GitHubAccountName, RepoName, newRelease);
               // (result.Id, newRelease);

            //await client.Repository.Release.Create(result.Id, newRelease);

            //var newReleaseResult = await client.Repository.Release.Create(result.Id, newRelease);
            //var tagsResult = await client.Repository.GetAllTags(result.Id);

            //var tagsResult = await client.Repository.GetAllTags(result.Id);

            //var tag = tagsResult.FirstOrDefault();

            //NewRelease data = newRelease;

            //Assert.True(true, PersonalAccessToken);

            Assert.True(true, result.ToString()); 


        }

    }
}


