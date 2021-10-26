using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OzonEdu.MerchApi.Grpc;
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

        public override async Task<MerchResponse> RequestMerch(Int64Value request, ServerCallContext context)
        {
            var merchItem = await _merchService.RequestMerch(request.Value, context.CancellationToken);

            return new MerchResponse
            {
                MerchName = merchItem.MerchName
            };
        }
    }
}