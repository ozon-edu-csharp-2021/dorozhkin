using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.HttpModels;

namespace OzonEdu.MerchApi.HttpClients
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5000");
            var client = new MerchHttpClient(httpClient);
            
            var v1RequestMerch = await client.V1RequestMerch(28, CancellationToken.None);
            var v1GetMerchIssueInfo = await client.V1GetMerchIssueInfo(new MerchIssuePostViewModel
            {
                MerchName = "Tshirt",
                EmployeeName = "Ivan"
            }, CancellationToken.None);
        }
    }
}