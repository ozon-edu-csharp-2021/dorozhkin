using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Models;

namespace OzonEdu.MerchApi.Services.Interfaces
{
    public interface IMerchService
    {
        Task<MerchItem> RequestMerch(long id, CancellationToken token);
        Task<MerchIssueInfo> GetMerchIssuesInfo(MerchIssueModel merchIssueModel, CancellationToken token);
    }
}