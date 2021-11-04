using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchApi.Domain.Events.MerchPackAggregate;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.DomainEvents
{
    public class SaveMerchPackEventHandler : INotificationHandler<SaveMerchPackEvent>
    {
        private readonly IMerchPackRepository _merchPackRepository;

        public SaveMerchPackEventHandler(IMerchPackRepository merchPackRepository)
        {
            _merchPackRepository = merchPackRepository;
        }

        public async Task Handle(SaveMerchPackEvent notification, CancellationToken cancellationToken)
        {
            await _merchPackRepository.UpdateAsync(notification.MerchPack, cancellationToken);
        }
    }
}