using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitReleaseAutomator
{
    public interface IReleaseAutomator
    {
        Task AsyncReleaseMethod(string gitHubAccountName, string repoName, string tagName, string personalAccessToken);
    }

}