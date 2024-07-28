using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace EventBooking.Application.Extensions
{
    public static class GetSecretExtension
    {
        public static string? GetSecret(this IConfiguration configuration)
        {
            var keyVaultUri = configuration.GetSection("KeyVault:KeyVaultURL").Value;
            var clientId = configuration.GetSection("KeyVault:ClientId").Value;
            var clientSecret = configuration.GetSection("KeyVault:ClientSecret").Value;
            var directoryId = configuration.GetSection("KeyVault:DirectoryId").Value;

            var credential = new ClientSecretCredential(directoryId, clientId, clientSecret);
            var secretClient = new SecretClient(new Uri(keyVaultUri!), credential);

            return secretClient.GetSecret("event-booking-api-secret")?.Value?.Value;
        }
    }
}
