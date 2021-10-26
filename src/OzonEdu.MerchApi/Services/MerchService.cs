using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Models;
using OzonEdu.MerchApi.Services.Interfaces;

namespace OzonEdu.MerchApi.Services
{
    public class MerchService : IMerchService
    {
        public Task<MerchItem> RequestMerch(long id, CancellationToken token)
        {
            // throw new System.NotImplementedException();

            return Task.FromResult(new MerchItem(id, $"NewMerch {id}"));
        }

        public Task<MerchIssueInfo> GetMerchIssuesInfo(MerchIssueModel merchIssueModel, CancellationToken token)
        {
            // throw new System.NotImplementedException();
            
            return Task.FromResult(new MerchIssueInfo(22, $"This Merch {merchIssueModel.MerchName}"));

        }
    }
}