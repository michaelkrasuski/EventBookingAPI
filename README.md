# EventBookingAPI
Application developed using dotnet 8 for training purposes. Used In-memory database with Entity Framework Core.

Application has been implemented using Clean Code Principles (CQRS) 

Authentication uses secret from Azure Key Vault.

Code is deployed using GitHub Actions workflow.

## Requirements to run locally
- dotnet core 8
- docker desktop

Application is deployed to azure and its publicly available using following address: https://demoeventbooking.azurewebsites.net/

Following endpoints require authentication:
- /api/Events/Create
- /api/Events/Update
- /api/Events/Delete
- /api/Events/Register

Authentication can be done using /api/Users/Authenticate endpoint. In a response Bearer token will be returned.

## References
- https://medium.com/@chezmohamed/clean-architecture-quick-setup-in-dotnet-core-8-e61386a5888b
- https://medium.com/@jeslurrahman/securing-net-api-secrets-with-azure-key-vault-net-core-8-70d9d8d3bc3b
