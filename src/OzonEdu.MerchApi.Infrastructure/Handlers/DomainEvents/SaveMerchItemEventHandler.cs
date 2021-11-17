using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchApi.Domain.Events.MerchPackAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.DomainEvents
{
    public class SaveMerchItemEventHandler : INotificationHandler<SaveMerchItemEvent>
    {
        private readonly IMerchPackRepository _merchPackRepository;

        public SaveMerchItemEventHandler(IMerchPackRepository merchPackRepository)
        {
            _merchPackRepository = merchPackRepository;
        }

        public async Task Handle(SaveMerchItemEvent notification, CancellationToken cancellationToken)
        {
            var merchItem = notification.MerchItem;
            await _merchPackRepository.CreateMerchItemByIdAsync(merchItem, cancellationToken);
        }
    }
}