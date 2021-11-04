using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Infrastructure.Commands.SubscribeToSupplyCommand;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.StockRequestAggregate
{
    public class SubscribeToSupplyCommandHandler : IRequestHandler<SubscribeToSupplyCommand, SubscribeToSupplyCommandResponse>
    {
        public async Task<SubscribeToSupplyCommandResponse> Handle(SubscribeToSupplyCommand request, CancellationToken cancellationToken)
        {
            //todo тут должен быть запрос на уведомление о поставке на склад через запрос к stock-api, но допустим он есть

            var subscribeToSupplyCommandResponse = new SubscribeToSupplyCommandResponse
            {
                SupplyCodeStatus = 228
            };

            return subscribeToSupplyCommandResponse;
        }
    }
}