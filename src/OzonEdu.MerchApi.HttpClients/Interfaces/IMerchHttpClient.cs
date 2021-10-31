using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.HttpModels;

namespace OzonEdu.MerchApi.HttpClients.Interfaces
{
    public interface IMerchHttpClient
    {
        Task<MerchItemResponse> V1RequestMerch(long id, CancellationToken token);

        Task<MerchIssueInfoResponse> V1GetMerchIssueInfo(MerchIssuePostViewModel merchIssuePostViewModel,
            CancellationToken token);
    }
}