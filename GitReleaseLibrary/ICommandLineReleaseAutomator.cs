﻿using CommandLine;

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
