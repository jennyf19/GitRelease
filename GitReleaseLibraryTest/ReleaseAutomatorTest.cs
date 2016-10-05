using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GitReleaseLibrary;
using Octokit;
using System.Threading.Tasks;
using Rhino.Mocks;


namespace GitReleaseLibraryTest
{
    [TestClass]
    public class ReleaseAutomatorTest
    {
       [TestMethod]
        public void AsyncReleaseMethodTest()
        {
            string gitHubAccountName = "jennyf19";
            string repoName = "cats";
            string tagName = "v1.1.1";
            string personalAccessToken = "1092urjlasakdjf;als";

            
            // Mock Repository.
            var _mockRepo = MockRepository.GenerateMock<Octokit.Repository>();
            _mockRepo.Stub(x => x.Id).Return(666);

            // Mock GitHubClient
            var _mockClient = MockRepository.GenerateMock<IGitHubClient>();

            // TODO: Do we need to mock the constructor?  ReleaseAutomator passes in new ProductHeaderValue("")...

            // Stub the Repository.Get() method.
            _mockClient.Stub(x => x.Repository.Get(gitHubAccountName, repoName))
                .Return(Task.Run(() => _mockRepo));

            // Stub the Repository.Content.GetReadmeHtml() method.
            _mockClient.Stub(x => x.Repository.Content.GetReadmeHtml(gitHubAccountName, repoName))
                .Return(Task.Run(() => "Fake ReadMe string?"));

            // Stub the Repository.Release.Create() method.
            _mockClient.Stub(x => x.Repository.Release.Create(_mockRepo.Id, new NewRelease("")))
                .Return(Task.Run(() => new Release()));

            var myReleaseAutomator = new ReleaseAutomator();
            //myReleaseAutomator.client = _mockClient;
            myReleaseAutomator.AsyncReleaseMethod(gitHubAccountName, repoName, tagName, personalAccessToken);


        }

    }

}
