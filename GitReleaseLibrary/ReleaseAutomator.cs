using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace GitReleaseLibrary
{
    public class ReleaseAutomator : IReleaseAutomator
    {
        public string GitHubAccountName { get; set; }
        public string RepoName { get; set; }
        public string TagName { get; set; }
        public string PersonalAccessToken { get; set; }
        public string Markdown { get; set; }

        public async void AsyncAuthenticationMethod(string GitHubAccountName, string RepoName, string TagName, string PersonalAccessToken, string Markdown)
        {
            //Test connection to GitHub API
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("Release"));

                try
                {
                    var tokenAuth = new Credentials(PersonalAccessToken);

                    client.Credentials = tokenAuth;
                }
                //Personal Access Token is invalid
                catch (ApiException e)
                {
                    Console.WriteLine(e);
                }

                try
                {
                    Repository result = await client.Repository.Get(GitHubAccountName, RepoName);

                    //All of the set parameters below must be correct (not case sensitive)
                    //If the TagName is equal to a tag name already used in a release, an exception will occur
                    //Create Tag
                    var newRelease = new NewRelease(TagName);

                    newRelease.Name = RepoName;

                    newRelease.Body = Markdown;

                    newRelease.Draft = false;

                    newRelease.Prerelease = false;

                    try
                    {
                        await client.Repository.Release.Create(result.Id, newRelease);

                        Console.WriteLine("\nRelease of " + RepoName + " complete");
                    }
                    catch (ApiValidationException e4)
                    {
                        Console.WriteLine(e4);
                    }
                    catch (ApiException e4a)
                    {
                        Console.WriteLine(e4a);
                    }
                }
                
                catch (NotFoundException e3)
                {
                    Console.WriteLine(e3);
                }
            }
            catch (AuthorizationException e1)
            {
                Console.WriteLine(e1);
            }
        }
    }
}

