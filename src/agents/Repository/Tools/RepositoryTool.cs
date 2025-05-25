namespace agents.Repository.Tools
{
    using System.ComponentModel;
    using Microsoft.SemanticKernel;

    public class RepositoryTool
    {
        [KernelFunction, Description("Adds the specified user email to the GitHub organization nucleo-tidz")]
        public bool AddToGithub(string userEmail)
        {
            return true;
        }

    }
}
