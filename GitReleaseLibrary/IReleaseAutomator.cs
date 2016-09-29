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
        /// The repo is tagged and released with the new of the repo, a name for the release.
        /// newRelease.Draft and newRelease.Prerelease are booleans and
        /// the defaults for both is false. 
        /// The README is pulled from the repo and included in the release
        /// </summary>
        string GitHubAccountName { get; set; }
        string RepoName { get; set; }
        string TagName { get; set; }
        string PersonalAccessToken { get; set; }
        //string Markdown { get; set; }

        void AsyncAuthenticationMethod(string GitHubAccountName, string RepoName, string TagName, string PersonalAccessToken);
        
}
    #endregion
}