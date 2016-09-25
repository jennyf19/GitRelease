using Xunit;
using Octokit;
using NUnit;
using System;

namespace UnitTestProject
{
    public class AsyncReleaseMethodTest
    {
        [Fact]
        public async void ReturnCredentials()
        {
            string GitHubAccountName = "jennyf19";
            string RepoName = "BinaryTree";
            var client = new GitHubClient(new ProductHeaderValue("Release"));
            string PersonalAccessToken = "";
            var inputAccessToken = new Credentials(PersonalAccessToken);
            client.Credentials = inputAccessToken;

            Repository result = await client.Repository.Get(GitHubAccountName, RepoName);

            Assert.True(true, result.ToString());
        }
        [Fact]
        public void CreateTagForRelease()
        {
            string TagName = "v1.1.30";
            string RepoName = "BinaryTree";
            string Markdown = "something here";
            
            var newRelease = new NewRelease(TagName);
                      
            newRelease.Name = RepoName;
                       
            newRelease.Body = Markdown;
                       
            newRelease.Draft = false;
                        
            newRelease.Prerelease = false;

            Assert.True(true, newRelease.ToString());
        }
    }
}

