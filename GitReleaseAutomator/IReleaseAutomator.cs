using System.Threading.Tasks;

namespace GitReleaseAutomator
{
    public interface IReleaseAutomator
    {
        Task AsyncReleaseMethod(string gitHubAccountName, string repoName, string tagName, string personalAccessToken);
    }

}