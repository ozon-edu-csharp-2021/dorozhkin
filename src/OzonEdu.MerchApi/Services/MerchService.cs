using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Models;
using OzonEdu.MerchApi.Services.Interfaces;

namespace OzonEdu.MerchApi.Services
{
    public class MerchService : IMerchService
    {
        public Task<MerchItem> RequestMerch(CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchIssuesInfo> GetMerchIssuesInfo(CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}