using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using CommandLine;
using CommandLine.Text;

namespace GitReleaseLibrary
{
    interface ICommandLineReleaseAutomator
    {
        [Option()]
        string GitHubAccountName { get; set; }

        [Option()]
        string RepoName { get; set; }

        [Option()]
        string TagName { get; set; }

        [Option()]
        string PersonalAccessToken { get; set; }

    }
}
