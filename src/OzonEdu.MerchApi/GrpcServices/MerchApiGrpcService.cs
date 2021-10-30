using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OzonEdu.MerchApi.Grpc;
using OzonEdu.MerchApi.Models;
using OzonEdu.MerchApi.Services.Interfaces;

namespace OzonEdu.MerchApi.GrpcServices
{
    public class MerchApiGrpcService : MerchApiGrpc.MerchApiGrpcBase
    {
        private readonly IMerchService _merchService;

        public MerchApiGrpcService(IMerchService merchService)
        {
            _merchService = merchService;
        }

        public override async Task<MerchResponse> RequestMerch(MerchRequest request, ServerCallContext context)
        {
            var merchItem = await _merchService.RequestMerch(request.Id, context.CancellationToken);

            return new MerchResponse
            {
                MerchName = merchItem.MerchName
            };
        }

        public override async Task<MerchIssueInfoResponse> GetMerchIssuesInfo(MerchIssueRequest request, ServerCallContext context)
        {
            var merchIssueModel = new MerchIssueModel(request.MerchName, request.EmployeeName);

            var merchIssueInfo = await _merchService.GetMerchIssuesInfo(merchIssueModel, context.CancellationToken);

            return new MerchIssueInfoResponse
            {
                MerchName = merchIssueInfo.MerchName,
                Quantity = merchIssueInfo.Quantity
            };
        }
    }
}