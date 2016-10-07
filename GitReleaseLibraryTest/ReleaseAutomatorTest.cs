using Microsoft.VisualStudio.TestTools.UnitTesting;
using GitReleaseAutomator;
using Octokit;
using System.Threading.Tasks;
using Rhino.Mocks;


namespace GitReleaseLibraryTest
{   
    [TestClass]
    public class ReleaseAutomatorTest
    {
        [TestMethod]
        public async Task AsyncReleaseMethodTest()
        {
            string gitHubAccountName = "AccountName";
            string repoName = "RepoName";
            string tagName = "v1.1.1";
            string personalAccessToken = "randomPersonalAccessToken";

            // Mock Repository.
            TestRepository Repository = new TestRepository();
            Repository.Id.Equals

            //var _mockRepo = MockRepository.GenerateStub<Octokit.Repository>();
            //_mockRepo.Stub(x => x.Id).Return(Repository.Id);

            Assert.AreEqual(Repository.Id, 666);

            /*
            // Mock GitHubClient
            var _mockClient = MockRepository.GenerateMock<IGitHubClient>();

            // Mock ProductHeaderValue
            var _mockHeaderValue = MockRepository.GenerateMock<ProductHeaderValue>();

            // Stub the Repository.Get() method.
            _mockClient.Stub(x => x.Repository.Get(gitHubAccountName, repoName))
                .Return(Task.Run(() => _mockRepo));

            // Stub the Repository.Content.GetReadmeHtml() method.
            _mockClient.Stub(x => x.Repository.Content.GetReadmeHtml(gitHubAccountName, repoName))
                .Return(Task.Run(() => "Fake ReadMe string?"));

            // Stub the Repository.Release.Create() method.
            _mockClient.Stub(x => x.Repository.Release.Create(_mockRepo.Id, new NewRelease("")))
                .Return(Task.Run(() => new Release()));

            // Stub the client.Credentials() method.
            _mockClient.Stub(x => x.Connection.Credentials.AuthenticationType.ToString(personalAccessToken))
                .Return(personalAccessToken);

            var myReleaseAutomator = new ReleaseAutomator();
            myReleaseAutomator.client = _mockClient;
            await myReleaseAutomator.AsyncReleaseMethod(gitHubAccountName, repoName, tagName, personalAccessToken);
            */
        }
        private class TestRepository : Repository
        {
            public int mockId { get; private set; }
            protected void Repository(int Id)
            {
                this.mockId = 666;
            }
        }
    }
}
