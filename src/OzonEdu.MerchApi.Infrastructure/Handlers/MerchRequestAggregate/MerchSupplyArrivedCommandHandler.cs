using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.Contracts;
using OzonEdu.MerchApi.Infrastructure.Commands.MerchSupplyArrivedCommand;
using OzonEdu.MerchApi.Infrastructure.Commands.ReserveMerchInStockCommand;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchRequestAggregate
{
    public class MerchSupplyArrivedCommandHandler : IRequestHandler<MerchSupplyArrivedCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMerchRequestRepository _merchRequestRepository;
        private readonly IMerchPackRepository _MerchPackRepository;
        private readonly IMediator _mediator;

        public MerchSupplyArrivedCommandHandler(IMerchRequestRepository merchRequestRepository, IMediator mediator,
            IUnitOfWork unitOfWork)
        {
            _merchRequestRepository = merchRequestRepository;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(MerchSupplyArrivedCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.StartTransaction(cancellationToken);

            var allRequests = await _merchRequestRepository.GetAllRequestsAsync(cancellationToken);

            var waitingSupplyRequests = allRequests
                .Where(merchRequest => merchRequest.Status == MerchRequestStatus.WaitingSupply).ToList();

            for (var i = 0; i < request.Quantity && i < waitingSupplyRequests.Count; i++)
            {
                var waitingSupplyRequest = waitingSupplyRequests[i];
                var merchPack =
                    await _MerchPackRepository.FindByIdAsync(waitingSupplyRequest.MerchPackId, cancellationToken);
                var skuList = merchPack.MerchItems.Select(merchItem => merchItem.Sku.Value);

                if (skuList != request.SkuCollection)
                    continue;

                var reserveMerchInStockCommand = new ReserveMerchInStockCommand
                {
                    SkuCollection = skuList
                };

                var response = await _mediator.Send(reserveMerchInStockCommand, cancellationToken);
                waitingSupplyRequests[i].SetInProcessStatus(response.ReserveCodeStatus);

                await _merchRequestRepository.UpdateAsync(waitingSupplyRequests[i], cancellationToken);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}