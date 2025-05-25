namespace agents.Orchestrator
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.SemanticKernel;
    using Microsoft.SemanticKernel.Agents;
    using Microsoft.SemanticKernel.Agents.Chat;

    public class Orchestrator(Kernel kernel)
    {
        private const string EmailAgentName = "EmailAgent";
        private const string RepositoryAgentName = "RepositoryAgent";
        private const string ProjectAgentName = "ProjectAgent";

        [Experimental("SKEXP0110")]
        public KernelFunctionSelectionStrategy CreateSelectionStrategy()
        {
            var selectionFunction = KernelFunctionFactory.CreateFromPrompt(
                  $$$"""
               Your job is to determine which participant (agent) should take the next turn in the onboarding process based on the conversation history.

               Choose only from these participants:
               - {{{EmailAgentName}}}
               - {{{RepositoryAgentName}}}
               - {{{ProjectAgentName}}}


               1. Start with {{{EmailAgentName}}} to create the official email and send a welcome message.
               2. If the last message was from {{{EmailAgentName}}} and contain a valid email, Then invoke {{{RepositoryAgentName}}} to grant access to the GitHub organization and code repositories.
               3. If the last message was from {{{RepositoryAgentName}}} and contains true, invoke {{{ProjectAgentName}}} to create a username in the project database and grant access to the web application.

               History:
               {{$history}}

               Return ONLY  the name of the next agent to act. Do NOT include any explanation or extra text.Just the name.
               """
            );  

            return new KernelFunctionSelectionStrategy(selectionFunction, kernel)
            {
                HistoryVariableName = "history",
               
            };
        }

        [Experimental("SKEXP0110")]
        public KernelFunctionTerminationStrategy CreateTerminationStrategy(ChatCompletionAgent[] agents)
        {
            var terminateFunction = KernelFunctionFactory.CreateFromPrompt(
                """
            Determine if the onboarding process is complete based on whether all three agents have completed their tasks:
            - EmailAgent has created the email and sent the welcome message.
            - RepositoryAgent has granted GitHub access.
            - ProjectAgent has created a username in the project database.

            If all three agents have completed their tasks, respond with a single word: yes.
            Otherwise, respond with: no.

            History:
            {{$history}}
            """
            );

            return new KernelFunctionTerminationStrategy(terminateFunction, kernel)
            {
                Agents = agents,
                ResultParser = result => result.GetValue<string>()?.Contains("yes", StringComparison.OrdinalIgnoreCase) ?? false,
                HistoryVariableName = "history",
                MaximumIterations = 10
            };
        }

        [Experimental("SKEXP0110")]
        public AgentGroupChatSettings CreateExecutionSettings(ChatCompletionAgent[] agents)
        {
            return new AgentGroupChatSettings()
            {
                TerminationStrategy = CreateTerminationStrategy(agents),
                
                SelectionStrategy = CreateSelectionStrategy(),
                
            };
        }
    }
}
