using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KeyvaultConsoleApp
{
    internal sealed class Program
    {
        private static async Task<int> Main(string[] args)
        {
            var host = CreateHostBuilder(args);
            await host.RunConsoleAsync();
            return Environment.ExitCode;
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) => 
                {
                    builder.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<IKeyvaultClient, KeyvaultClient>();
                });
    }
}
