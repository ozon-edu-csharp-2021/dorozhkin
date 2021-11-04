using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects;
using OzonEdu.MerchApi.Infrastructure.Commands.MerchSupplyArrivedCommand;
using OzonEdu.MerchApi.Infrastructure.Commands.ReserveMerchInStockCommand;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchRequestAggregate
{
    public class MerchSupplyArrivedCommandHandler : IRequestHandler<MerchSupplyArrivedCommand>
    {
        private readonly IMerchRequestRepository _merchRequestRepository;
        private readonly IMediator _mediator;

        public MerchSupplyArrivedCommandHandler(IMerchRequestRepository merchRequestRepository, IMediator mediator)
        {
            _merchRequestRepository = merchRequestRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(MerchSupplyArrivedCommand request, CancellationToken cancellationToken)
        {
            var allRequests = await _merchRequestRepository.GetAllRequestsAsync(cancellationToken);

            var waitingSupplyRequests = allRequests
                .Where(merchRequest => merchRequest.Status == MerchRequestStatus.WaitingSupply).ToList();

            var queueRequests = waitingSupplyRequests
                .Where(waitingSupplyRequest => waitingSupplyRequest.SkuList == request.SkuCollection).ToList();

            for (int i = 0; i < request.Quantity; i++)
            {
                var reserveMerchInStockCommand = new ReserveMerchInStockCommand
                {
                    SkuCollection = queueRequests[i].SkuList
                };
                
                var response = await _mediator.Send(reserveMerchInStockCommand);
                queueRequests[i].SetInProcessStatus(response.ReserveCodeStatus);
                
                await _merchRequestRepository.UpdateAsync(queueRequests[i]);
            }

            return Unit.Value;
        }
    }
}