namespace agents.Group
{
    using System.Diagnostics.CodeAnalysis;

    using agents.Email;
    using agents.Orchestrator;
    using agents.ProjectAccess;
    using agents.Repository;

    using Microsoft.SemanticKernel;
    using Microsoft.SemanticKernel.Agents;

    [Experimental("SKEXP0110")]
    public class GroupAgent()
    {
        public AgentGroupChat CreateAgentGroupChat(Kernel kernel)
        {

            var emailAgent = new EmailAgent().Create(kernel);
            var repoAgent = new RepositoryAgent().Create(kernel);
            var projectAgent = new ProjectAgent().Create(kernel);


            var chatOrchestrator = new Orchestrator(kernel);

            return new AgentGroupChat(emailAgent, repoAgent, projectAgent)
            {
                ExecutionSettings = chatOrchestrator.CreateExecutionSettings([projectAgent])

            };
        }
    }
}
