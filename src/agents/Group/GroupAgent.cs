namespace agents.Group
{
    using System.Diagnostics.CodeAnalysis;

    using agents.Email;
    using agents.ProjectAccess;
    using agents.Repository;
    using agents.Orchestrator;
    using Microsoft.SemanticKernel;
    using Microsoft.SemanticKernel.Agents;

    [Experimental("SKEXP0110")]
    public class GroupAgent(Kernel kernel)
    {
        public AgentGroupChat CreateAgentGroupChat()
        {

            var emailAgent = new EmailAgent(kernel).Create(); 
            var repoAgent = new RepositoryAgent(kernel).Create();
            var projectAgent = new ProjectAgent(kernel).Create();


            var chatOrchestrator = new Orchestrator(kernel);

            return new AgentGroupChat(emailAgent, repoAgent, projectAgent)
            {
                ExecutionSettings = chatOrchestrator.CreateExecutionSettings([projectAgent])                

            };
        }
    }
}
