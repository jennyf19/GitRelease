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
    interface ICommandLineInputParser
    {
        [Option()]
        string gitHubAccountName { get; set; }

        [Option()]
        string repoName { get; set; }

        [Option()]
        string tagName { get; set; }

        [Option()]
        string personalAccessToken { get; set; }

    }
}
