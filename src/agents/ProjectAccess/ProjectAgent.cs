namespace agents.ProjectAccess
{
    using agents.Email.Tools;
    using agents.ProjectAccess.Tools;
    using agents.Repository.Tools;

    using Microsoft.SemanticKernel;
    using Microsoft.SemanticKernel.Agents;
    public class ProjectAgent()
    {
        public ChatCompletionAgent Create(Kernel kernel)
        {
            Kernel agentKernel = kernel.Clone();
            agentKernel.ImportPluginFromType<ProjectTool>();
            return new ChatCompletionAgent()
            {
                Name = "ProjectAgent",
                Instructions = @" You are an AI agent responsible for granting the onboarded user access to the web application project by creating a corresponding username in the project’s database. Use the provided email address to generate the username",
                Kernel = agentKernel,
                Arguments = new KernelArguments(new PromptExecutionSettings()
                {
                    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
                })
            };
        }
    }
}
