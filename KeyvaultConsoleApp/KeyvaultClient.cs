using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace KeyvaultConsoleApp
{
    internal class KeyvaultClient : IKeyvaultClient
    {
        private readonly IConfiguration configuration;

        public KeyvaultClient(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task FetchConnectionStringsFromKeyvault()
        {
            var keyvault = configuration.GetValue<string>("AZURE_KEYVAULT_URI");
            var client = new SecretClient(new Uri(keyvault), new DefaultAzureCredential());
            var response = await client.GetSecretAsync("myservice-eventhubs-connectionstring");
            Console.WriteLine($"Event Hubs Connection String {response.Value.Value}");
        }
    }
}