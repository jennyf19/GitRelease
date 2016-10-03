using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GitReleaseLibrary;

namespace GitReleaseLibraryTest
{
    [TestClass]
    public class ReleaseAutomatorTest
    {
        [TestMethod]
        public void AsyncReleaseMethodGetClientTest()
        {
            string gitHubAccountName = "jennyf19";
            string repoName = "binaryTree";
            string tagName = "v1.11.11";
            string personalAccessToken = "127c0389c7a3ca4854bde31a22cf99f4285d4028";

            ReleaseAutomator releaseAutomator = new ReleaseAutomator();
            releaseAutomator.AsyncReleaseMethod(gitHubAccountName, repoName, tagName, personalAccessToken);

            Assert.AreEqual();


        }
    }
}
