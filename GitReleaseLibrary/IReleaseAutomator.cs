﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitReleaseLibrary
{
    public interface IReleaseAutomator
    {
        string gitHubAccountName { get; set; }
        string repoName { get; set; }
        string tagName { get; set; }
        string personalAccessToken { get; set; }

        Task AsyncReleaseMethod(string gitHubAccountName, string repoName, string tagName, string personalAccessToken);
    }

}