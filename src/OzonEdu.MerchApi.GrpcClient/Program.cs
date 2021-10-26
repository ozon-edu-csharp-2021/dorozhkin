using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using OzonEdu.MerchApi.Grpc;

namespace OzonEdu.MerchApi.GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var client = new MerchApiGrpc.MerchApiGrpcClient(channel);

            // var response = await client.RequestMerchAsync(new Int64Value{Value = 228}, cancellationToken: CancellationToken.None);
            
            var response = await client.GetMerchIssuesInfoAsync(new MerchIssueRequest
            {
                MerchName = "T-shirt",
                EmployeeName = "Ivan"
            }, cancellationToken: CancellationToken.None);
            
            Console.WriteLine(response.MerchName);
        }
    }
}