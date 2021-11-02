using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Infrastructure.Commands;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchRequestAggregate
{
    public class RequestMerchCommandHandler : IRequestHandler<RequestMerchCommand, RequestMerchCommandResponse>
    {
        public async Task<RequestMerchCommandResponse> Handle(RequestMerchCommand request, CancellationToken cancellationToken)
        {
            var requestMerchCommandResponse = new RequestMerchCommandResponse
            {
                Status = $"Created for {request.EmployeeId} with {request.MerchPackId}"
            };

            return requestMerchCommandResponse;
        }
    }
}