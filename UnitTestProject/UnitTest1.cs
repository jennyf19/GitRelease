using Xunit;
using Octokit;
using NUnit;
using System;
using System.Linq;
using Octokit.Internal;
using CommandLine;
using CommandLine.Text;


namespace UnitTestProject
{
    public class Options
    {
        /*[Option('g', "GitHubAccount", Required = true, HelpText = "Enter the GitHub Account Name for the repository you want to release")]
       public string GitHubAccountName { get; set; }

      [Option('r', "RepoName", Required = true, HelpText = "Enter the name of the repository you want to release")]
       public string RepoName { get; set; }*/
    }

    public class AsyncReleaseMethodTest
    {

        public class ReleaseAutomator
        {
            
            public string GitHubAccountName { get; set; }
            public string RepoName { get; set; }
            public string TagName { get; set; }
            public string PersonalAccessToken { get; set; }
            public string Markdown { get; set; }

            public async void AsyncAuthenticationMethod(string GitHubAccountName, string RepoName, string TagName, string PersonalAccessToken, string Markdown)
            {
                try
                {
                    var client = new GitHubClient(new ProductHeaderValue("Release"));

                    try
                    {
                        var tokenAuth = new Credentials(PersonalAccessToken);

                        client.Credentials = tokenAuth;
                    }

                    catch (AuthorizationException e)
                    {
                        Console.WriteLine("Your personal access token is invalid", e);
                    }

                    //new Credentials(PersonalAccessToken);

                    Repository result = await client.Repository.Get(GitHubAccountName, RepoName);
                }
                catch (ApiException e1)
                {
                    Console.WriteLine(e1);
                }


                /*[Fact]
                public void CommandLineInputGitHubAccountName()
                {
                    var options = new Options();

                    string GitHubAccountName = options.GitHubAccountName;
                    Assert.Contains("jennyf19", GitHubAccountName);
                }

                 [Fact]
                 public void CommandLineInputRepoName()
                 {
                     var options = new Options();
                     string RepoName = options.RepoName;
                     Assert.Contains(RepoName, "binaryTree");*/

            }

        }
    }
}






