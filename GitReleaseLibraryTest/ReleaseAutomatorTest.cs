using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GitReleaseLibrary;

namespace GitReleaseLibraryTest
{
    [TestClass]
    public class ReleaseAutomatorTestExceptedGitHubAccountName : IReleaseAutomator
    {
        string gitHubAccountName { get; set; }
        string repoName { get; set; }
        string tagName { get; set; }
        string personalAccessToken { get; set; }

        [TestMethod]
        public void AsyncReleaseMethod(string gitHubAccountName, string repoName, string tagName, string personalAccessToken)
        {
        
        }
    }
}
