namespace agents.Email.Tools
{
    using System.ComponentModel;

    using Microsoft.SemanticKernel;

    public class EmailTool
    {
        [KernelFunction, Description("Generates a professional company email address in the format firstname.lastname@nucleotidz.com based on the provided first and last name.")]
        public string CreateEmail(string firstName, string secondName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(secondName))
            {
                throw new ArgumentException("First name and second name must be provided.");
            }
            return $"{firstName}.{secondName}@nucleotidz.com";
        }

        [KernelFunction, Description("Sends a welcome email to the specified email address using the provided email body content.")]
        public bool SendWelcomeEmail(string body, string to)
        {
            return true;
        }
    }
}
