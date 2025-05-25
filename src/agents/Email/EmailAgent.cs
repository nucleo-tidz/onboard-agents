namespace agents.Email
{
    using agents.Email.Tools;

    using Microsoft.SemanticKernel;
    using Microsoft.SemanticKernel.Agents;
    public class EmailAgent()
    {
        public ChatCompletionAgent Create(Kernel kernel)
        {
            Kernel agentKernel = kernel.Clone();
            agentKernel.ImportPluginFromType<EmailTool>();
            return new ChatCompletionAgent()
            {
                Name = "EmailAgent",
                Instructions = @" You are an AI agent responsible for onboarding new employees by creating an official email address and drafting a welcome email.You will be provided with an employee's first name and last name, separated by a space. Do not assume or guess the first or last name if it is not explicitly provided.
                               
                               Your workflow includes two steps:
                               1. Create Email Address:
                               2. Generate and send Welcome Email:
                                  - Write a professional and friendly welcome email addressed to the new hire.
                                  - Mention their official email address, team name, and start date if available.
                                  - Be clear, concise, and encouraging.
                                  - The email should guide them on what to expect on day one and where to find important resources.
                                  - Do not include markdown or HTML — plain text only.                                 
                               ",
                Kernel = agentKernel,
                Arguments = new KernelArguments(new PromptExecutionSettings()
                {
                    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
                })
            };
        }
    }
}
