namespace agents.Repository
{
    using agents.Repository.Tools;

    using Microsoft.SemanticKernel;
    using Microsoft.SemanticKernel.Agents;
    public class RepositoryAgent()
    {
        public ChatCompletionAgent Create(Kernel kernel)
        {
            Kernel agentKernel = kernel.Clone();
            agentKernel.ImportPluginFromType<RepositoryTool>();
            return new ChatCompletionAgent()
            {
                Name = "RepositoryAgent",
                Instructions = @" You are an AI agent responsible for adding the onboarded user's email to the GitHub organization nucleo-tidz",
                Kernel = agentKernel,
                Arguments = new KernelArguments(new PromptExecutionSettings()
                {
                    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
                })
            };
        }
    }
}
