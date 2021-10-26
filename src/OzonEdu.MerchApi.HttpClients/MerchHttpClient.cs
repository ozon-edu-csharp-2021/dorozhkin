using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OzonEdu.MerchApi.HttpClients.Interfaces;
using OzonEdu.MerchApi.HttpModels;

namespace OzonEdu.MerchApi.HttpClients
{
    public class MerchHttpClient : IMerchHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MerchItemResponse> V1RequestMerch(long id, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merch/{id}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonConvert.DeserializeObject<MerchItemResponse>(body);
        }
        
        public async Task<MerchIssueInfoResponse> V1GetMerchIssueInfo(MerchIssuePostViewModel merchIssuePostViewModel, CancellationToken token)
        {
            using var response = await _httpClient.PostAsJsonAsync("v1/api/merch/", merchIssuePostViewModel, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonConvert.DeserializeObject<MerchIssueInfoResponse>(body);
        }
    }
}