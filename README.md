# Onboarding Multi-Agent AI with Semantic Kernel

## Overview

This project demonstrates a Proof of Concept (PoC) for an AI-powered onboarding system using Microsoft Semantic Kernel with multiple agents working in orchestration. It automates key onboarding steps for new employees:

- **EmailAgent**: Creates official company email addresses and sends welcome emails.
- **RepositoryAgent**: Adds the user to the GitHub organization `nucleo-tidz` and grants repository access.
- **ProjectAgent**: Creates a username in the web application’s project database to grant project access.

The system uses a **KernelFunctionSelectionStrategy** to orchestrate the agents sequentially, ensuring a smooth onboarding flow.

---

## Features

- Automated email creation and welcome messaging.
- GitHub organization and repository access provisioning.
- User creation and access grant within project databases.
- Orchestrated multi-agent workflow controlled by a custom function selection strategy.
- Extensible design for adding more onboarding steps or agents.

---

## Technologies Used

- Microsoft Semantic Kernel
- C# .NET 7+
- Azure OpenAI / OpenAI (for chat completions and reasoning)

