using CommandLine;
using System;
using Octokit;
using System.Threading.Tasks;

namespace GitReleaseAutomator
{
    public class GitHubVCSClient : IVCSClient
    {
        public IVCSCredentials Credentials { get; set; }


    }

    public class GitHubVCSRepository
    {
       
    }
}