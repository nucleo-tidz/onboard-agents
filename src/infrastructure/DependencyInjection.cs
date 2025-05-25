using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

namespace infrastructure
{
    [Experimental(diagnosticId: "SKEXP0070")]
    public static class DependencyInjection
    {

        public static IServiceCollection AddSemanticKernel(this IServiceCollection services, IConfiguration configuration, bool useGoogle = true)
        {

            return services.AddTransient<Kernel>(serviceProvider =>
            {
                IKernelBuilder kernelBuilder = Kernel.CreateBuilder();
                if (useGoogle)
                {
                    kernelBuilder.Services.AddGoogleAIGeminiChatCompletion("gemini-2.0-flash", configuration["GeminiKey"], serviceId: "gpt-4-turbo");
                }
                else
                {
                    kernelBuilder.Services.AddAzureOpenAIChatCompletion("gpt-4o",
                       "https://ahmar-m7ohej9z-eastus2.cognitiveservices.azure.com/",
                       configuration["APIKey"],
                       "gpt-4o",
                       "gpt-4o");
                }
                return kernelBuilder.Build();
            });
        }
    }
}
