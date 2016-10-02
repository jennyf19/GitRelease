using System;
using CommandLine;
using CommandLine.Text;
using Octokit;
using System.Text.RegularExpressions;

namespace GitRelease
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
    public class CommandLineInputParser : ICommandLineInputParser
    {
        [Option('g', "GitHubAccount", Required = true, HelpText = "Enter the GitHub Account Name for the repository you want to release")]
        public string gitHubAccountName { get; set; }

        [Option('r', "RepoName", Required = true, HelpText = "Enter the name of the repository you want to release")]
        public string repoName { get; set; }

        [Option('t', "TagName", Required = true, HelpText = "Enter the tag name for the repository you want to release (ex. v1.0.0")]
        public string tagName { get; set; }

        [Option('p', "PersonalAccessToken", Required = true, HelpText = "Enter the personal access token for the account")]
        public string personalAccessToken { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
    interface ITagNameFormatCheck
    {
        string tagName { get; set; }

        bool TagNameFormat(string tagName);
    }
    public class TagNameFormatCheck : ITagNameFormatCheck
    {
        public string tagName { get; set; }

        public bool TagNameFormat(string tagName)
        {
            Regex tagNamePattern = new Regex(@"^v[1-9]\.([0-9][0-9]\.)([0-9][0-9])$");

            if (Regex.IsMatch(tagName, tagNamePattern.ToString()) && tagName != null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
    interface IReleaseAutomator
    {
        string gitHubAccountName { get; set; }
        string repoName { get; set; }
        string tagName { get; set; }
        string personalAccessToken { get; set; }

        void AsyncReleaseMethod(string gitHubAccountName, string repoName, string tagName, string personalAccessToken);
    }
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
