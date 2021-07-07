using System.Threading.Tasks;

namespace KeyvaultConsoleApp
{
    internal interface IKeyvaultClient
    {
        Task FetchConnectionStringsFromKeyvault();
    }
}