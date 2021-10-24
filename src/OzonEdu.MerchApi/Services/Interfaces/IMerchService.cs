using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Models;

namespace OzonEdu.MerchApi.Services.Interfaces
{
    public interface IMerchService
    {
        Task<MerchItem> RequestMerch(CancellationToken token);
        Task<MerchIssuesInfo> GetMerchIssuesInfo(CancellationToken token);
    }
}