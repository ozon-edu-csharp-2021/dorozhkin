using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects;
using OzonEdu.MerchApi.Infrastructure.Commands.MerchDeliveredCommand;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchRequestAggregate
{
    public class MerchDeliveredToEmployeeCommandHandler : IRequestHandler<MerchDeliveredToEmployeeCommand>
    {
        private readonly IMerchRequestRepository _requestRepository;

        public MerchDeliveredToEmployeeCommandHandler(IMerchRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<Unit> Handle(MerchDeliveredToEmployeeCommand request, CancellationToken cancellationToken)
        {
            var allRequests = await _requestRepository.GetAllRequestsAsync(cancellationToken);


            var inProcessRequests = allRequests
                .Where(merchRequest => merchRequest.Status == MerchRequestStatus.WaitingSupply).ToList();

            var completedRequest =
                inProcessRequests.FirstOrDefault(x => x.ReserveCodeStatus == request.ReserveCodeStatus);

            if (completedRequest is null)
                throw new Exception("Reserve code was not found");
            
            completedRequest.SetClosedStatus(request.DeliveryCode);

            await _requestRepository.UpdateAsync(completedRequest, cancellationToken);
            
            //todo send email to employee
            
            return Unit.Value;
        }
    }
}