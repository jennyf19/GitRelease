using System;
using Octokit;

namespace GitReleaseLibrary
{
    public class ReleaseAutomator : IReleaseAutomator
    {
        public string gitHubAccountName { get; set; }
        public string repoName { get; set; }
        public string tagName { get; set; }
        public string personalAccessToken { get; set; }
        
        public async void AsyncReleaseMethod(string gitHubAccountName, string repoName, string tagName, string personalAccessToken)
        {
            //Test connection to GitHub API
            try
            //ApiException e1
            {
                var client = new GitHubClient(new ProductHeaderValue("Release"));

                try
                //ApiException e2
                {
                    var tokenAuth = new Credentials(personalAccessToken);

                    client.Credentials = tokenAuth;
                }
                //Personal Access Token is invalid
                catch (ApiException e2)
                {
                    Console.WriteLine(e2);
                }

                try
                //AuthorizationException e3
                {
                    Repository result = await client.Repository.Get(gitHubAccountName, repoName);

                    try
                    //ApiException e4
                    {
                        string readMe = await client.Repository.Content.GetReadmeHtml(gitHubAccountName, repoName);
                        

                        //All of the set parameters below must be correct (not case sensitive)
                        //If the TagName is equal to a tag name already used in a release, an exception will occur
                        //Create Tag

                        var newRelease = new NewRelease(tagName);

                        newRelease.Name = repoName;

                        newRelease.Body = readMe.ToString();

                        newRelease.Draft = false;

                        newRelease.Prerelease = false;

                        try
                        //ApiValidationException e5
                        {
                            await client.Repository.Release.Create(result.Id, newRelease);

                            Console.WriteLine("\nRelease of " + repoName + " complete");
                        }
                        catch (ApiValidationException e5)
                        {
                            Console.WriteLine(e5);
                        }
                    }
                    catch (NotFoundException e4)
                    {
                        Console.WriteLine(e4);
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