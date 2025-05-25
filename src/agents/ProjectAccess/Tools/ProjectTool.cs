namespace agents.ProjectAccess.Tools
{
    using System.ComponentModel;

    using Microsoft.SemanticKernel;

    public class ProjectTool
    {
        [KernelFunction, Description("Creates a username in the project’s database for the specified user email to grant access to the web application.")]
        public bool CreateUserName(string userEmail)
        {
            return true;
        }
    }
}
