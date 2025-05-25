namespace client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using agents.Email;

    using Microsoft.SemanticKernel;
    using Microsoft.SemanticKernel.ChatCompletion;

    public class BootStrapper : IBootStrapper
    {
        private readonly Kernel _kernel;
        public BootStrapper(Kernel kernel)
        {
            _kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
        }
        public async Task Run()
        {
            var emailAgent = new EmailAgent(_kernel).Create();
            ChatHistory chatHistory = new ChatHistory();
            while (true)
            {
                string query = Console.ReadLine();
                chatHistory.Add(new Microsoft.SemanticKernel.ChatMessageContent { Role = AuthorRole.User, Content = query });
                await foreach (var message in emailAgent.InvokeAsync(chatHistory))
                {
                     
                }
            }
        }
    }
}
