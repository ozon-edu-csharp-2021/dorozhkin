using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchApi.Domain.Events.MerchRequestAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.DomainEvents
{
    public class SaveMerchRequestEventHandler : INotificationHandler<SaveMerchRequestEvent>
    {
        private readonly IMerchRequestRepository _merchRequestRepository;

        public SaveMerchRequestEventHandler(IMerchRequestRepository merchRequestRepository)
        {
            _merchRequestRepository = merchRequestRepository;
        }

        public async Task Handle(SaveMerchRequestEvent notification, CancellationToken cancellationToken)
        {
            var merchRequest = notification.MerchRequest;
            await _merchRequestRepository.UpdateAsync(merchRequest, cancellationToken);
        }
    }
}