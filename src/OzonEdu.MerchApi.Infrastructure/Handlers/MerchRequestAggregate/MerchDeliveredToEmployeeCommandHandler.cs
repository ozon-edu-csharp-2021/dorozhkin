using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.Contracts;
using OzonEdu.MerchApi.Infrastructure.Commands.MerchDeliveredCommand;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchRequestAggregate
{
    public class MerchDeliveredToEmployeeCommandHandler : IRequestHandler<MerchDeliveredToEmployeeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMerchRequestRepository _requestRepository;

        public MerchDeliveredToEmployeeCommandHandler(IMerchRequestRepository requestRepository, IUnitOfWork unitOfWork)
        {
            _requestRepository = requestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(MerchDeliveredToEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.StartTransaction(cancellationToken);
            var allRequests = await _requestRepository.GetAllRequestsAsync(cancellationToken);

            var inProcessRequests = allRequests
                .Where(merchRequest => merchRequest.Status == MerchRequestStatus.WaitingSupply).ToList();

            var completedRequest =
                inProcessRequests.FirstOrDefault(x => x.ReserveCodeStatus == request.ReserveCodeStatus);

            if (completedRequest is null)
                throw new Exception("Reserve code was not found");
            
            completedRequest.SetClosedStatus(request.DeliveryCode);

            await _requestRepository.UpdateAsync(completedRequest, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            //todo send email to employee
            
            return Unit.Value;
        }
    }
}